using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Humans.Common.Projections.Visits;
using CMS_BE.Domain.Aggregates.Materials;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Common.Validators.Visits
{
    public class PrescriptionValidator : AbstractValidator<PrescriptionModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public PrescriptionValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.DrugId)
                .NotEmpty()
                .WithMessage("Hãy chọn thuốc")
                .MustAsync(
                    async (model, id, ctx) =>
                    {
                        var check = await unitOfWork
                            .Repository<Drug>()
                            .AnyAsync(x => x.Id == Ulid.Parse(id), ctx);
                        return check;
                    }
                )
                .WithMessage("Thuốc không tồn tại");

            RuleFor(x => x.Dosage)
                .NotEmpty()
                .WithMessage("Vui lòng nhập liều dùng")
                .MaximumLength(200)
                .WithMessage("Độ dài không vượt quá 200 ký tự");
            RuleFor(x => x.Quantity).LessThan(0).WithMessage("Số lượng phải lớn hơn không");
            RuleFor(x => x.UnitId)
                .NotEmpty()
                .WithMessage("Hãy chọn đơn vị")
                .MustAsync(
                    async (model, id, ctx) =>
                    {
                        var check = await unitOfWork
                            .Repository<Drug>()
                            .AnyAsync(
                                x =>
                                    x.Units.Any(x => x.Id == Ulid.Parse(id))
                                    && x.Id == Ulid.Parse(model.DrugId),
                                ctx
                            );
                        return check;
                    }
                )
                .WithMessage("Đơn vị thuốc không tồn tại");
        }
    }
}
