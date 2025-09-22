using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Features.Humans.Patients.Commands;
using CMS_BE.Application.Features.Humans.Patients.Commands.Delete;
using CMS_BE.Application.Features.Humans.Patients.Commands.Update;
using CMS_BE.Application.Features.Humans.Patients.Queries.Detail;
using CMS_BE.Application.Features.Humans.Patients.Queries.List;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CMS_BE.Presentation.Endpoints.Patients
{
    [ApiExplorerSettings(GroupName = "v1")]
    public class CreatePatientsEndpoints(ISender sender)
        : EndpointBaseAsync.WithRequest<CreatePatientCommand>.WithActionResult<ApiResponse>
    {
        [HttpPost(Router.PatientRoute.Patients)]
        [SwaggerOperation(Tags = [Router.PatientRoute.Tags], Summary = "Create a new patient")]
        public override async Task<ActionResult<ApiResponse>> HandleAsync(
            [FromBody] CreatePatientCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
