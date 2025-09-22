using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using CMS_BE.Application.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Patients.Commands.Update
{
    public class UpdatePatientCommand : IRequest<Result>
    {
        [FromRoute(Name = RouterBase.Id)]
        public string Id { get; set; } = default!;

        [FromBody]
        public PatientModel Model { get; set; } = default!;
    }
}
