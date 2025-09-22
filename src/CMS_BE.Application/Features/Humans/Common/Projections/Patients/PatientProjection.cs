using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Domain.Aggregates.Humans;
using CMS_BE.Domain.Aggregates.Humans.Enums;

namespace CMS_BE.Application.Features.Humans.Common.Projections.Patients
{
    public class PatientProjection : BaseResponse
    {
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int NumberVisits { get; set; }
    }

    public class PatientDetailProjection : PatientProjection
    {
        public string? Note { get; set; }

        public ContactProjection Contact { get; set; } = null!;

        public virtual void MappingFrom(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            Age = patient.Age;
            Gender = patient.Gender;
            Note = patient.Note;
            NumberVisits = patient.Visits.Count;
            if (patient.Contact != null)
            {
                Contact = new ContactProjection();
                Contact.MappingFrom(patient.Contact);
            }
        }
    }
}
