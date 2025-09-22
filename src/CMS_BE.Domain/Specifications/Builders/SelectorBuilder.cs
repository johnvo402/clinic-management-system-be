using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CMS_BE.Domain.Specifications.Interfaces;

namespace CMS_BE.Domain.Specifications.Builders
{
    public static class SelectorBuilder
    {
        public static ISpecificationBuilder<T, TResponse> Select<T, TResponse>(
            this ISpecificationBuilder<T, TResponse> builder,
            Expression<Func<T, TResponse>> selector
        )
            where T : class
            where TResponse : class
        {
            builder.Spec!.Selector = selector;

            return builder;
        }
    }
}
