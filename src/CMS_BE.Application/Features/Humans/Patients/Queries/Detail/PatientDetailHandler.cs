using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Humans;
using CMS_BE.Domain.Aggregates.Humans.Specifications;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.Detail
{
    public class PatientDetailHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<PatientDetailQuery, Result<PatientDetailResponse>>
    {
        public async ValueTask<Result<PatientDetailResponse>> Handle(
            PatientDetailQuery request,
            CancellationToken cancellationToken
        )
        {
            var patient = await unitOfWork
                .DynamicReadOnlyRepository<Patient>()
                .FindByConditionAsync(
                    new GetPatientDetailSpecification(Ulid.Parse(request.Id)),
                    x => x.ToResponse(),
                    cancellationToken
                );
            if (patient == null)
            {
                return Result<PatientDetailResponse>.Failure(
                    new NotFoundError("Không tìm thấy", "Không tìm thấy bệnh nhân")
                );
            }
            return Result<PatientDetailResponse>.Success(patient);
        }
    }
}
