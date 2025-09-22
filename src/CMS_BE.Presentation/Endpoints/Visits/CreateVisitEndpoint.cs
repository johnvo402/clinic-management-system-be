using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Visits.Commands.Create;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CMS_BE.Presentation.Endpoints.Visits
{
    public class CreateVisitEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<CreateVisitCommand>.WithActionResult<ApiResponse>
    {
        [HttpPost(Router.VisitRoute.CreateByPatient)]
        [SwaggerOperation(Tags = [Router.VisitRoute.Tags], Summary = "Create visit for a patient")]
        public override async Task<ActionResult<ApiResponse>> HandleAsync(
            CreateVisitCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
