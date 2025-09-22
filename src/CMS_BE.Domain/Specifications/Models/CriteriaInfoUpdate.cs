using System.Linq.Expressions;
using CMS_BE.Domain.Specification.Models;

namespace CMS_BE.Domain.Specifications.Models
{
    public class CriteriaInfoUpdate<T>
        where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; } = null!;

        public string? Key { get; set; }

        public BinaryExpressionType Type { get; set; }
    }
}
