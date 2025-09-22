using System.Collections.ObjectModel;
using CMS_BE.Domain.Common;

namespace CMS_BE.Domain.Aggregates.Humans
{
    public class Visit : BaseEntity
    {
        public Ulid PatientId { get; set; }
        public DateTimeOffset VisitDate { get; set; }
        public string Symptoms { get; set; } = default!;
        public string Diagnosis { get; set; } = default!;
        public string? Note { get; set; }
        public Patient Patient { get; set; } = default!;
        public ICollection<Prescription> Prescriptions { get; set; } = [];
    }
}
