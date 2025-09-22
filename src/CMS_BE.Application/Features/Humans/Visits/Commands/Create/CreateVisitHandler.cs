using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Humans;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Create
{
    public class CreateVisitHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CreateVisitCommand, Result>
    {
        public async ValueTask<Result> Handle(
            CreateVisitCommand request,
            CancellationToken cancellationToken
        )
        {
            var patient = await unitOfWork
                .Repository<Patient>()
                .FindByIdAsync(request.PatientId, cancellationToken);
            if (patient is null)
            {
                return Result.Failure(
                    new NotFoundError("Không tìm thấy", "Không tìm thấy bệnh nhân")
                );
            }
            var visit = request.ToEntity();
            patient.Visits.Add(visit);

            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<Patient>().UpdateAsync(patient);
                await unitOfWork.SaveAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return Result.Success();
            }
            catch (System.Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
