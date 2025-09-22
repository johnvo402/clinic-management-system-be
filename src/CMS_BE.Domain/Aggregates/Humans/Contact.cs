using CMS_BE.Domain.Common;

namespace CMS_BE.Domain.Aggregates.Humans
{
    public class Contact : DefaultEntity
    {
        public Ulid PatientId { get; set; } = default!;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Patient Patient { get; set; } = default!;
    }
}
