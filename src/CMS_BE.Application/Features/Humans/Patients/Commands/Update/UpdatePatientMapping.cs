using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Patients.Commands.Update
{
    public static class UpdatePatientMapping
    {
        public static void ToEntity(this Patient patient, PatientModel command)
        {
            patient.Update(command.FullName!, command.Age, command.Gender, command.Note);
        }
    }
}
