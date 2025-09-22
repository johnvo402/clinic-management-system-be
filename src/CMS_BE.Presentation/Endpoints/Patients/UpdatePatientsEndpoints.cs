using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Patients.Commands.Update;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Presentation.Endpoints.Patients
{
    public class UpdatePatientsEndpoints(ISender sender)
        : EndpointBaseAsync.WithRequest<UpdatePatientCommand>.WithActionResult<ApiResponse>
    {
        public override async Task<ActionResult<ApiResponse>> HandleAsync(
            UpdatePatientCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
