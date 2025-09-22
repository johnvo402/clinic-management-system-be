using CMS_BE.Application.Common.DTOs.Responses;

namespace CMS_BE.Application.Common.Interfaces.Token
{
    public interface ITokenFactory
    {
        public DateTime AccesstokenExpiredTime { get; }

        public DateTime RefreshtokenExpiredTime { get; }

        DecodeTokenResponse DecodeToken(string token);

        string CreateToken(
            IEnumerable<KeyValuePair<string, object>> claims,
            DateTime expirationTime
        );
    }
}
