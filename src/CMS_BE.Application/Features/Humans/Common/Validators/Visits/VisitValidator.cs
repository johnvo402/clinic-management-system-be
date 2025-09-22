using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Humans.Common.Projections.Visits;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Common.Validators.Visits
{
    public class VisitValidator : AbstractValidator<VisitModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public VisitValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Symptoms)
                .NotEmpty()
                .WithMessage("Triệu chứng không được để trống")
                .MaximumLength(500)
                .WithMessage("Triệu chứng không được vượt quá 500 ký tự");

            RuleFor(x => x.Diagnosis)
                .NotEmpty()
                .WithMessage("Chẩn đoán không được để trống")
                .MaximumLength(500)
                .WithMessage("Chẩn đoán không được vượt quá 500 ký tự");

            RuleFor(x => x.Note)
                .MaximumLength(500)
                .WithMessage("Ghi chú không được vượt quá 500 ký tự");

            RuleForEach(x => x.PrescriptionModel)
                .SetValidator(new PrescriptionValidator(unitOfWork));
        }
    }
}
