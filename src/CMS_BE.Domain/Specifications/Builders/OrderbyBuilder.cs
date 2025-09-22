using System.Linq.Expressions;
using CMS_BE.Domain.Specifications.Interfaces;
using CMS_BE.Domain.Specifications.Models;

namespace CMS_BE.Domain.Specifications.Builders
{
    public static class OrderbyBuilder
    {
        public static ISpecificationBuilder<T> OrderBy<T>(
            this ISpecificationBuilder<T> builder,
            Expression<Func<T, object>> orderby
        )
            where T : class
        {
            var orderbyInfo = new OrderByInfo<T>()
            {
                KeySelector = orderby,
                OrderType = OrderType.Asc,
            };
            builder.Spec!.Sorts.Add(orderbyInfo);
            return builder;
        }

        public static ISpecificationBuilder<T> OrderByDescending<T>(
            this ISpecificationBuilder<T> builder,
            Expression<Func<T, object>> orderby
        )
            where T : class
        {
            var orderbyInfo = new OrderByInfo<T>()
            {
                KeySelector = orderby,
                OrderType = OrderType.Desc,
            };
            builder.Spec!.Sorts.Add(orderbyInfo);
            return builder;
        }

        public static ISpecificationBuilder<T> ThenBy<T>(
            this ISpecificationBuilder<T> builder,
            Expression<Func<T, object>> orderby
        )
            where T : class
        {
            var orderbyInfo = new OrderByInfo<T>()
            {
                KeySelector = orderby,
                OrderType = OrderType.Asc,
                IsThenBy = true,
            };
            builder.Spec!.Sorts.Add(orderbyInfo);
            return builder;
        }

        public static ISpecificationBuilder<T> ThenByDescending<T>(
            this ISpecificationBuilder<T> builder,
            Expression<Func<T, object>> orderby
        )
            where T : class
        {
            var orderbyInfo = new OrderByInfo<T>()
            {
                KeySelector = orderby,
                OrderType = OrderType.Desc,
                IsThenBy = true,
            };
            builder.Spec!.Sorts.Add(orderbyInfo);
            return builder;
        }
    }
}
