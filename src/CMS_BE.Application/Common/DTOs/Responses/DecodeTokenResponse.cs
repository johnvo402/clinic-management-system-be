using System.Text.Json.Serialization;

namespace CMS_BE.Application.Common.DTOs.Responses
{
    public class DecodeTokenResponse
    {
        [JsonPropertyName("sub")]
        public string? Sub { get; set; }

        [JsonPropertyName("exp")]
        public long? ExpiredTime { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
