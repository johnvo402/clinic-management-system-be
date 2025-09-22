using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Delete
{
    public class DeleteVisitCommand : IRequest<Result>
    {
        [FromRoute(Name = RouterBase.Id)]
        public string Id { get; set; } = default!;
    }
}
