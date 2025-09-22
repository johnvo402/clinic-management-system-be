using CMS_BE.Domain.Aggregates.Humans.Enums;

namespace CMS_BE.Application.Features.Humans.Common.Projections.Patients
{
    public class PatientModel
    {
        public string? FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? Note { get; set; }
    }
}
