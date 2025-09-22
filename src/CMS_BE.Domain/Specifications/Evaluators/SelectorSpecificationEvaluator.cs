using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Domain.Specifications.Interfaces;

namespace CMS_BE.Domain.Specifications.Evaluators
{
    public class SelectorSpecificationEvaluator
    {
        public static IQueryable<TResponse> GetQuery<T, TResponse>(
            IQueryable<T> inputQuery,
            ISpecification<T, TResponse> specification
        )
            where T : class
            where TResponse : class
        {
            IQueryable<T> query = inputQuery;
            return query.Select(specification.Selector);
        }
    }
}
