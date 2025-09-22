using System.Data.Common;

namespace CMS_BE.Application.Common.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public DbTransaction? CurrentTransaction { get; protected set; }

        IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Read-only operations combine dynamic queries and specification pattern
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="isCached">Do cache or not</param>
        /// <returns></returns>
        IDynamicSpecificationRepository<TEntity> DynamicReadOnlyRepository<TEntity>()
            where TEntity : class;

        Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);

        Task RollbackAsync(CancellationToken cancellationToken = default);

        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
