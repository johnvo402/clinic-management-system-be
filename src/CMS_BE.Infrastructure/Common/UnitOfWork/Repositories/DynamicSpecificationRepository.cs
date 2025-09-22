using System.Linq.Expressions;
using CMS_BE.Application.Common.DTOs.Requests;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Common.Extensions.QueryExtensions;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Domain.Specifications.Evaluators;
using CMS_BE.Domain.Specifications.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS_BE.Infrastructure.Common.UnitOfWork.Repositories
{
    public class DynamicSpecificationRepository<T>(IDbContext dbContext)
        : IDynamicSpecificationRepository<T>
        where T : class
    {
        public async Task<T?> FindByConditionAsync(
            ISpecification<T> spec,
            CancellationToken cancellationToken = default
        ) => await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);

        public async Task<TResult?> FindByConditionAsync<TResult>(
            ISpecification<T> spec,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        )
            where TResult : class =>
            await ApplySpecification(spec)
                .Select(mappingResult)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<IList<T>> ListAsync(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            CancellationToken cancellationToken = default
        )
        {
            string uniqueSort = queryParam.Sort.GetSort();

            return await ApplySpecification(spec)
                .Filter(queryParam.Filter)
                .Search(queryParam.Keyword, queryParam.Targets)
                .Sort(uniqueSort)
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<TResult>> ListAsync<TResult>(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        )
            where TResult : class
        {
            string uniqueSort = queryParam.Sort.GetSort();

            return await ApplySpecification(spec)
                .Filter(queryParam.Filter)
                .Search(queryParam.Keyword, queryParam.Targets)
                .Sort(uniqueSort)
                .Select(mappingResult)
                .ToListAsync(cancellationToken);
        }

        public async Task<PaginationResponse<TResult>> PagedListAsync<TResult>(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        )
        {
            string uniqueSort = queryParam.Sort.GetSort();

            return await ApplySpecification(spec)
                .Filter(queryParam.Filter)
                .Search(queryParam.Keyword, queryParam.Targets)
                .Sort(uniqueSort)
                .Select(mappingResult)
                .ToPagedListAsync(queryParam.Page, queryParam.PageSize, cancellationToken);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec) =>
            SpecificationEvaluator.GetQuery(dbContext.Set<T>().AsQueryable(), spec);
    }
}
