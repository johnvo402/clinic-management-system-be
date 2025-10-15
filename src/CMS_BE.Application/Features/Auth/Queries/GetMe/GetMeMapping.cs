using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Domain.Aggregates.Auth;

namespace CMS_BE.Application.Features.Auth.Queries.GetMe
{
    public static class GetMeMapping
    {
        public static GetMeResponse ToGetMeResponse(this Account account)
        {
            var response = new GetMeResponse();
            response.MappingFrom(account);
            return response;
        }
    }
}
