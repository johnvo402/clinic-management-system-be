namespace CMS_BE.Domain.Common
{
    public interface IBaseAuditable
    {
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
