using CMS_BE.Application.Common.DTOs.Responses;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Common.Projections.Patients
{
    public class ContactProjection : DefaultBaseResponse
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public virtual void MappingFrom(Contact contact)
        {
            Id = contact.Id;
            PhoneNumber = contact.PhoneNumber;
            Address = contact.Address;
        }
    }
}
