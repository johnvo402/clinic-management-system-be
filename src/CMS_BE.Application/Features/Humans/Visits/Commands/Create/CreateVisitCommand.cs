using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Common.Projections.Visits;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Create
{
    public class CreateVisitCommand : IRequest<Result>
    {
        [FromRoute(Name = nameof(PatientId))]
        public string PatientId { get; set; } = default!;

        [FromBody]
        public VisitModel Model { get; set; } = default!;
    }
}
