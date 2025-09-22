using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.Detail
{
    public class PatientDetailQuery : IRequest<Result<PatientDetailResponse>>
    {
        [FromRoute(Name = RouterBase.Id)]
        public string Id { get; set; } = null!;
    }
}
