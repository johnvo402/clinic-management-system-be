using System.Text.RegularExpressions;

namespace CMS_BE.Application.Features.Auth.Common
{
    public static partial class AuthUtil
    {
        [GeneratedRegex(@"^((?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9]).{8,})\S$")]
        public static partial Regex PasswordValidationRegex();
    }
}
