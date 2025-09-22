using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.ApiWrapper
{
    public abstract class ErrorDetails
    {
        public int Status { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }

        public List<InvalidParam>? InvalidParams { get; set; }
        public string? ErrorMessage { get; set; }

        public ErrorDetails(
            string title,
            List<InvalidParam> invalidParams,
            string? type = null,
            int? status = null
        )
        {
            Title = title;
            Status = status ?? StatusCodes.Status500InternalServerError;
            InvalidParams = invalidParams;
            Type = type ?? "InternalException";
        }

        public ErrorDetails(
            string title,
            string erorMessage,
            string? type = null,
            int? status = null
        )
        {
            Title = title;
            Status = status ?? StatusCodes.Status500InternalServerError;
            ErrorMessage = erorMessage;
            Type = type ?? "InternalException";
        }
    }
}
