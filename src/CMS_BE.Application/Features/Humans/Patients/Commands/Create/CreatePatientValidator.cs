using CMS_BE.Application.Features.Humans.Common.Validators.Patients;
using FluentValidation;

namespace CMS_BE.Application.Features.Humans.Patients.Commands
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            Include(new PatientValidator());
        }
    }
}
