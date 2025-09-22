using CMS_BE.Application.Features.Materials.Common.Projections;
using FluentValidation;

namespace CMS_BE.Application.Features.Materials.Common.Validators
{
    public class DrugValidator : AbstractValidator<DrugModel>
    {
        public DrugValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Tên thuốc là bắt buộc.")
                .MaximumLength(200)
                .WithMessage("Tên thuốc không được vượt quá 200 ký tự.");

            RuleFor(d => d.Price).GreaterThan(0).WithMessage("Giá thuốc phải lớn hơn 0.");

            RuleForEach(d => d.Units)
                .ChildRules(units =>
                {
                    units
                        .RuleFor(u => u.Name)
                        .NotEmpty()
                        .WithMessage("Tên đơn vị là bắt buộc.")
                        .MaximumLength(100)
                        .WithMessage("Tên đơn vị không được vượt quá 100 ký tự.");

                    units
                        .RuleFor(u => u.Multiple)
                        .GreaterThan(0)
                        .WithMessage("Hệ số nhân phải lớn hơn 0.");
                });
        }
    }
}
