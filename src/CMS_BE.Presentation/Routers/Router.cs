using CMS_BE.Application.Routers;

namespace CMS_BE.Presentation.Routers
{
    public class Router
    {
        public static class PatientRoute
        {
            public const string Patients = $"{RouterBase.prefix}{nameof(Patients)}";
            public const string GetUpdateDelete =
                $"{RouterBase.prefix}{nameof(Patients)}/" + "{" + RouterBase.Id + "}";
            public const string GetRouteName = $"{Patients}DetailEndpoint";
            public const string GetList = $"{RouterBase.prefix}{nameof(Patients)}";
            public const string Tags = $"{nameof(Patients)} endpoint";
        }

        public static class AuthRoute
        {
            public const string Auth = $"{RouterBase.prefix}{nameof(Auth)}";

            public const string Login = $"{Auth}/{nameof(Login)}";
            public const string AuthTags = $"{nameof(Auth)} endpoint";

            public const string RefreshToken = $"{Auth}/{nameof(RefreshToken)}";
        }

        public static class VisitRoute
        {
            public const string Visits = $"{RouterBase.prefix}{nameof(Visits)}";
            public const string CreateByPatient =
                $"{RouterBase.prefix}{nameof(Visits)}/" + "{PatientId}" + $"/{nameof(Visits)}";
            public const string GetUpdateDelete =
                $"{RouterBase.prefix}{nameof(Visits)}/" + "{" + RouterBase.Id + "}";
            public const string Tags = $"{nameof(Visits)} endpoint";
        }
    }
}
