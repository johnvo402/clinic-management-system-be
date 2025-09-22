using System.Linq.Expressions;

namespace CMS_BE.Domain.Specifications.Models
{
    public class OrderByInfo<T>
    {
        public Expression<Func<T, object>> KeySelector { get; set; } = null!;

        public OrderType OrderType { get; set; }

        public bool IsThenBy { get; set; }
    }
}
