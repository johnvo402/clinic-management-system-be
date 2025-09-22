using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Common.QueryStringProcessing;
using CMS_BE.Domain.Aggregates.Humans;
using CMS_BE.Domain.Aggregates.Humans.Specifications;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Visits.Queries.ListByPatient
{
    public class ListVisitsByPatientHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<
            ListVisitsByPatientQuery,
            Result<PaginationResponse<ListVisitsByPatientResponse>>
        >
    {
        public async ValueTask<Result<PaginationResponse<ListVisitsByPatientResponse>>> Handle(
            ListVisitsByPatientQuery request,
            CancellationToken cancellationToken
        )
        {
            var validator = request.Validate<
                ListVisitsByPatientQuery,
                ListVisitsByPatientResponse
            >();
            if (validator != null)
            {
                return validator;
            }
            var results = await unitOfWork
                .DynamicReadOnlyRepository<Visit>()
                .PagedListAsync(
                    new VisitsByPatientSpecification(Ulid.Parse(request.PatientId)),
                    request,
                    ListVisitsByPatientMapping.Selector(),
                    cancellationToken
                );

            return Result<PaginationResponse<ListVisitsByPatientResponse>>.Success(results);
        }
    }
}
