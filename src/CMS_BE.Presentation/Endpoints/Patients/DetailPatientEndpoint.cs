using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Patients.Queries.Detail;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Presentation.Endpoints.Patients
{
    public class DetailPatientEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<PatientDetailQuery>.WithActionResult<
            ApiResponse<PatientDetailResponse>
        >
    {
        public override async Task<ActionResult<ApiResponse<PatientDetailResponse>>> HandleAsync(
            PatientDetailQuery request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
