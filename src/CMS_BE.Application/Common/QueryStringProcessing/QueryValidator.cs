using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Requests;
using CMS_BE.Application.Common.DTOs.Responses;

namespace CMS_BE.Application.Common.QueryStringProcessing
{
    public static class QueryValidator
    {
        public static Result<PaginationResponse<TResponse>>? Validate<TQuery, TResponse>(
            this TQuery query
        )
            where TQuery : QueryParamRequest
            where TResponse : class
        {
            var validationResult = query.ValidateQuery();
            if (validationResult.Error != null)
            {
                return Result<PaginationResponse<TResponse>>.Failure(validationResult.Error);
            }

            var validationFilterResult = query.ValidateFilter<TQuery, TResponse>();
            if (validationFilterResult.Error != null)
            {
                return Result<PaginationResponse<TResponse>>.Failure(validationFilterResult.Error);
            }

            return null;
        }

        public static Result<TResponse>? ValidateWithoutPaging<TQuery, TResponse>(this TQuery query)
            where TQuery : QueryParamRequest
            where TResponse : class
        {
            var validationResult = query.ValidateQuery();
            if (validationResult.Error != null)
            {
                return Result<TResponse>.Failure(validationResult.Error);
            }

            var validationFilterResult = query.ValidateFilter<TQuery, TResponse>();
            if (validationFilterResult.Error != null)
            {
                return Result<TResponse>.Failure(validationFilterResult.Error);
            }

            return null;
        }
    }
}
