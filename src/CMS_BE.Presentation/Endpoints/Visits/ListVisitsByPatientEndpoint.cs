using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Features.Humans.Visits.Queries.ListByPatient;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CMS_BE.Presentation.Endpoints.Visits
{
    public class ListVisitsByPatientEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<ListVisitsByPatientQuery>.WithActionResult<
            ApiResponse<PaginationResponse<ListVisitsByPatientResponse>>
        >
    {
        [HttpGet(Router.VisitRoute.CreateByPatient)]
        [SwaggerOperation(Tags = [Router.VisitRoute.Tags], Summary = "List visits by patient")]
        public override async Task<
            ActionResult<ApiResponse<PaginationResponse<ListVisitsByPatientResponse>>>
        > HandleAsync(
            ListVisitsByPatientQuery request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
