using System.Data;
using CMS_BE.Application.Features.Humans.Common.Validators.Patients;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Patients.Commands.Update
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Model).SetValidator(new PatientValidator());
        }
    }
}
