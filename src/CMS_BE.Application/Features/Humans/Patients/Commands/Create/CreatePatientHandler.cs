using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Humans.Patients.Commands.Create;
using CMS_BE.Domain.Aggregates.Humans;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Commands
{
    public class CreatePatientHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CreatePatientCommand, Result>
    {
        public async ValueTask<Result> Handle(
            CreatePatientCommand request,
            CancellationToken cancellationToken
        )
        {
            Patient patient = request.ToEntity();

            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<Patient>().AddAsync(patient, cancellationToken);
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
