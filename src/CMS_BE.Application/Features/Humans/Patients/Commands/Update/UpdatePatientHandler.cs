using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Humans;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Commands.Update
{
    public class UpdatePatientHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<UpdatePatientCommand, Result>
    {
        public async ValueTask<Result> Handle(
            UpdatePatientCommand request,
            CancellationToken cancellationToken
        )
        {
            var id = Ulid.Parse(request.Id);
            var patient = await unitOfWork
                .Repository<Patient>()
                .FindByIdAsync(id, cancellationToken);
            if (patient is null)
            {
                return Result.Failure(
                    new NotFoundError( "Không tìm thấy bệnh nhân")
                );
            }

            patient.ToEntity(request.Model);

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
