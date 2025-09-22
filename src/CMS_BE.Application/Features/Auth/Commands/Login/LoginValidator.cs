using System.Text.RegularExpressions;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Features.Auth.Common;
using CMS_BE.Domain.Aggregates.Auth;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CMS_BE.Application.Features.Auth.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Tên đăng nhập là bắt buộc.")
                .MaximumLength(50)
                .WithMessage("Tên đăng nhập không được vượt quá 50 ký tự.")
                .MustAsync(IsAccountExisted)
                .WithMessage("Tài khoản không tồn tại trong hệ thống.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Mật khẩu là bắt buộc.")
                .MinimumLength(6)
                .WithMessage("Mật khẩu phải có ít nhất 6 ký tự.")
                .Must(x =>
                {
                    Regex regex = AuthUtil.PasswordValidationRegex();
                    return regex.IsMatch(x!);
                })
                .WithMessage(
                    "Mật khẩu phải chứa ít nhất 1 chữ in hoa, 1 chữ in thường và 1 số."
                )
                .MaximumLength(60)
                .WithMessage("Mật khẩu không được vượt quá 60 ký tự.");
        }

        private Task<bool> IsAccountExisted(string username, CancellationToken cancellationToken)
        {
            return unitOfWork
                .Repository<Account>()
                .AnyAsync(x => EF.Functions.ILike(username, x.Username), cancellationToken);
        }
    }
}
