using System.Data;
using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Common.Validators.Patients
{
    public class PatientValidator : AbstractValidator<PatientModel>
    {
        public PatientValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                .WithMessage("Tên không được để trống.")
                .MaximumLength(100)
                .WithMessage("Tên không được vượt quá 100 ký tự.");

            RuleFor(p => p.Age)
                .InclusiveBetween(0, 120)
                .WithMessage("Age must be between 0 and 120.");

            RuleFor(p => p.Gender).IsInEnum().WithMessage("Giới tính không hợp lệ.");

            RuleFor(p => p.Note)
                .MaximumLength(500)
                .WithMessage("Ghi chú không được vượt quá 500 ký tự.");
        }
    }
}
