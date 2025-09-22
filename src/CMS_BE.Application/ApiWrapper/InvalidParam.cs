namespace CMS_BE.Application.ApiWrapper
{
    public class InvalidParam
    {
        public string? PropertyName { get; set; }

        public IEnumerable<ErrorReason> Reasons { get; set; } = [];
    }

    public class ErrorReason
    {
        public string? Message { get; set; }
    }
}
