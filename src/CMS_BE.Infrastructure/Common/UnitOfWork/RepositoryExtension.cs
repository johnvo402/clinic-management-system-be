using CMS_BE.Application.Common.DTOs.Models;
using CMS_BE.Domain.Common;

namespace CMS_BE.Infrastructure.Common.UnitOfWork
{
    public static class RepositoryExtension
    {
        public static string GetSort(this string? sort)
        {
            string defaultSort = GetDefaultSort(sort);
            return $"{defaultSort},{nameof(BaseEntity.Id)}";
        }

        public static string GetDefaultSort(this string? sort) =>
            string.IsNullOrWhiteSpace(sort)
                ? $"{nameof(BaseEntity.CreatedAt)}{OrderTerm.DELIMITER}{OrderTerm.DESC}"
                : sort.Trim();
    }
}
