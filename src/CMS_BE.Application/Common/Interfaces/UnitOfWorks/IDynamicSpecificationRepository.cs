using System.Linq.Expressions;
using CMS_BE.Application.Common.DTOs.Requests;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Domain.Specifications.Interfaces;

namespace CMS_BE.Application.Common.Interfaces.UnitOfWorks
{
    public interface IDynamicSpecificationRepository<T> : IRepository<T>
        where T : class
    {
        Task<T?> FindByConditionAsync(
            ISpecification<T> spec,
            CancellationToken cancellationToken = default
        );

        Task<TResult?> FindByConditionAsync<TResult>(
            ISpecification<T> spec,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        )
            where TResult : class;

        Task<IList<T>> ListAsync(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            CancellationToken cancellationToken = default
        );

        Task<IList<TResult>> ListAsync<TResult>(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        )
            where TResult : class;

        Task<PaginationResponse<TResult>> PagedListAsync<TResult>(
            ISpecification<T> spec,
            QueryParamRequest queryParam,
            Expression<Func<T, TResult>> mappingResult,
            CancellationToken cancellationToken = default
        );
    }
}
