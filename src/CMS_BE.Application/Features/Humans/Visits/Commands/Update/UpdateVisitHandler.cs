using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Extensions;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Humans;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Update
{
    public class UpdateVisitHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateVisitCommand, Result>
    {
        public async ValueTask<Result> Handle(
            UpdateVisitCommand request,
            CancellationToken cancellationToken
        )
        {
            var id = Ulid.Parse(request.Id);
            var visit = await unitOfWork.Repository<Visit>().FindByIdAsync(id, cancellationToken);
            if (visit is null)
            {
                return Result.Failure(
                    new NotFoundError("Không tìm thấy", "Không tìm thấy lần khám")
                );
            }

            visit.Symptoms = request.Model.Symptoms;
            visit.Diagnosis = request.Model.Diagnosis;
            visit.Note = request.Model.Note;
            visit.Prescriptions = request
                .Model.PrescriptionModel.Select(x => new Prescription
                {
                    Dosage = x.Dosage,
                    Quantity = x.Quantity,
                    DrugId = Ulid.Parse(x.DrugId),
                    UnitId = Ulid.Parse(x.UnitId),
                })
                .ToListIfNot();

            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<Visit>().UpdateAsync(visit);
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
