using System.Data.Common;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Infrastructure.Common.UnitOfWork.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace CMS_BE.Infrastructure.Common.UnitOfWork
{
    public class UnitOfWork(IDbContext dbContext, ILogger logger) : IUnitOfWork
    {
        public DbTransaction? CurrentTransaction { get; set; }

        private object? repositories { get; set; } = null;

        private bool disposed = false;

        public IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : class
        {
            Type repositoryType = typeof(AsyncRepository<>);
            object? repositoryInstance = CreateInstance<TEntity>(repositoryType, dbContext);

            return (IAsyncRepository<TEntity>)repositoryInstance!;
        }

        public IDynamicSpecificationRepository<TEntity> DynamicReadOnlyRepository<TEntity>()
            where TEntity : class
        {
            Type repositoryType = typeof(DynamicSpecificationRepository<>);
            object? repositoryInstance = CreateInstance<TEntity>(repositoryType, dbContext);

            return (IDynamicSpecificationRepository<TEntity>)repositoryInstance!;
        }

        public async Task<DbTransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default
        )
        {
            if (CurrentTransaction != null || dbContext.DatabaseFacade.CurrentTransaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            IDbContextTransaction currentTransaction =
                await dbContext.DatabaseFacade.BeginTransactionAsync(cancellationToken);

            CurrentTransaction = currentTransaction.GetDbTransaction();
            return CurrentTransaction;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (CurrentTransaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }

            try
            {
                await CurrentTransaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await RollbackAsync(cancellationToken);
                throw new Exception("Transaction commit failed. Rolled back.", ex);
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (CurrentTransaction == null)
            {
                logger.Warning("Thre is no transaction started.");
                return;
            }

            try
            {
                await CurrentTransaction.RollbackAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Transaction rollback failed.", ex);
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters) =>
            dbContext.DatabaseFacade.ExecuteSqlRaw(sql, parameters);

        public async Task SaveAsync(CancellationToken cancellationToken = default) =>
            await dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            repositories = null;
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                dbContext.Dispose();
            }

            disposed = true;
        }

        private async Task DisposeTransactionAsync()
        {
            if (CurrentTransaction != null)
            {
                await CurrentTransaction.DisposeAsync();
                CurrentTransaction = null;
            }
        }

        private static object? CreateInstance<T>(Type genericType, params object?[]? args)
            where T : class =>
            Activator.CreateInstance(genericType.MakeGenericType(typeof(T)), args);
    }
}
