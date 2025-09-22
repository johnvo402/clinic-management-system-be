using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Humans.Common.Validators.Visits;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Update
{
    public class UpdateVisitValidator : AbstractValidator<UpdateVisitCommand>
    {
        private IUnitOfWork unitOfWork;

        public UpdateVisitValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Model).SetValidator(new VisitValidator(unitOfWork));
        }
    }
}
