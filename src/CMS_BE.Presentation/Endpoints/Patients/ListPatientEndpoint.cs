using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Features.Humans.Patients.Queries.List;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Presentation.Endpoints.Patients
{
    public class ListPatientEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<ListPatientQuery>.WithActionResult<
            ApiResponse<PaginationResponse<ListPatientResponse>>
        >
    {
        [HttpGet(Router.PatientRoute.GetList)]
        public override async Task<
            ActionResult<ApiResponse<PaginationResponse<ListPatientResponse>>>
        > HandleAsync(
            [FromQuery] ListPatientQuery request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
