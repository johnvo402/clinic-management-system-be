using Ardalis.GuardClauses;
using CMS_BE.Domain.Aggregates.Humans.Enums;
using CMS_BE.Domain.Common;
using Mediator;

namespace CMS_BE.Domain.Aggregates.Humans
{
    public class Patient : AggregateRoot
    {
        public string FullName { get; private set; } = default!;
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public string? Note { get; set; }
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
        public Contact Contact { get; set; } = default!;

        public Patient() { }

        public Patient(string fullName, int age, Gender gender, string? note = null)
        {
            FullName = Guard.Against.NullOrEmpty(fullName, nameof(FullName));
            Age = Guard.Against.NegativeOrZero(age, nameof(Age));
            Gender = Guard.Against.EnumOutOfRange(gender, nameof(Gender));
            Note = note;
        }

        public void Update(
            string? fullName = null,
            int? age = null,
            Gender? gender = null,
            string? note = null
        )
        {
            if (fullName != null)
                FullName = Guard.Against.NullOrEmpty(fullName, nameof(FullName));
            if (age != null)
                Age = Guard.Against.NegativeOrZero(age.Value, nameof(Age));
            if (gender != null)
                Gender = Guard.Against.EnumOutOfRange(gender.Value, nameof(Gender));
            if (note != Note)
                Note = note;
        }

        public void UpdateContact(string phoneNumber, string address)
        {
            if (Contact == null)
            {
                Contact = new Contact
                {
                    PatientId = this.Id,
                    PhoneNumber = phoneNumber,
                    Address = address,
                };
            }
            else
            {
                Contact.PhoneNumber = phoneNumber;
                Contact.Address = address;
            }
        }

        protected override bool TryApplyDomainEvent(INotification domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
