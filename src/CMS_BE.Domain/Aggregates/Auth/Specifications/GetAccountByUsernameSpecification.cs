using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Domain.Specifications;
using CMS_BE.Domain.Specifications.Builders;
using Microsoft.EntityFrameworkCore;

namespace CMS_BE.Domain.Aggregates.Auth.Specifications
{
    public class GetAccountByUsernameSpecification : Specification<Account>
    {
        public GetAccountByUsernameSpecification(string username)
        {
            Query.Where(x => EF.Functions.ILike(x.Username, username)).AsNoTracking();
        }
    }
}
