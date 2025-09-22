using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Common.QueryStringProcessing;
using CMS_BE.Domain.Aggregates.Humans;
using CMS_BE.Domain.Aggregates.Humans.Specifications;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.List
{
    public class ListPatientHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<ListPatientQuery, Result<PaginationResponse<ListPatientResponse>>>
    {
        public async ValueTask<Result<PaginationResponse<ListPatientResponse>>> Handle(
            ListPatientQuery request,
            CancellationToken cancellationToken
        )
        {
            var validation = request.Validate<ListPatientQuery, ListPatientResponse>();
            if (validation != null)
            {
                return validation;
            }

            var results = await unitOfWork
                .DynamicReadOnlyRepository<Patient>()
                .PagedListAsync(
                    new ListPatientSpecification(),
                    request,
                    ListPatientMapping.Selector(),
                    cancellationToken
                );

            return Result<PaginationResponse<ListPatientResponse>>.Success(results);
        }
    }
}
