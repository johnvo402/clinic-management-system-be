using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Requests;
using CMS_BE.Application.Common.DTOs.Responses;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.List
{
    public class ListPatientQuery
        : QueryParamRequest,
            IRequest<Result<PaginationResponse<ListPatientResponse>>>;
}
