using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Common.Projections.Visits;
using CMS_BE.Application.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Update
{
    public class UpdateVisitCommand : IRequest<Result>
    {
        [FromRoute(Name = RouterBase.Id)]
        public string Id { get; set; } = default!;

        [FromBody]
        public VisitModel Model { get; set; }
    }
}
