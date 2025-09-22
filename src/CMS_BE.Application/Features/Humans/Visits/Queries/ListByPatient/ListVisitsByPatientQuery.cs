using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Requests;
using CMS_BE.Application.Common.DTOs.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Features.Humans.Visits.Queries.ListByPatient
{
    public class ListVisitsByPatientQuery
        : QueryParamRequest,
            IRequest<Result<PaginationResponse<ListVisitsByPatientResponse>>>
    {
        [FromRoute(Name = nameof(PatientId))]
        public string PatientId { get; set; } = default!;
    }
}
