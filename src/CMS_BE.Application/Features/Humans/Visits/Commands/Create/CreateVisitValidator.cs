using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Humans.Common.Validators.Visits;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Create
{
    public class CreateVisitValidator : AbstractValidator<CreateVisitCommand>
    {
        private IUnitOfWork unitOfWork;

        public CreateVisitValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.PatientId).NotEmpty().WithMessage("Mã bệnh nhân không được để trống");
            RuleFor(x => x.Model).SetValidator(new VisitValidator(unitOfWork));
        }
    }
}
