using CMS_BE.Domain.Common;

namespace CMS_BE.Application.Common.DTOs.Responses
{
    public class BaseResponse : DefaultBaseResponse, IBaseAuditable
    {
        public string CreatedBy { get; set; } = string.Empty;

        public string? UpdatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class DefaultBaseResponse
    {
        public Ulid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class BaseResponse<T> : DefaultBaseResponse<T>, IBaseAuditable
    {
        public string CreatedBy { get; set; } = string.Empty;

        public string? UpdatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class DefaultBaseResponse<T>
    {
        public T Id { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
