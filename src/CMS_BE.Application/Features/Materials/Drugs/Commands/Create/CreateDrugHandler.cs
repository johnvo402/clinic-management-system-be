using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Domain.Aggregates.Materials;
using Mediator;

namespace CMS_BE.Application.Features.Materials.Drugs.Commands.Create
{
    public class CreateDrugHandler(IUnitOfWork unitOfWork)
        : ICommandHandler<CreateDrugCommand, Result>
    {
        public async ValueTask<Result> Handle(
            CreateDrugCommand request,
            CancellationToken cancellationToken
        )
        {
            Drug entity = request.ToEntity();
            try
            {
                await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<Drug>().AddAsync(entity, cancellationToken);
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
