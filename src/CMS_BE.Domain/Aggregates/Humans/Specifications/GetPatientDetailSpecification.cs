using CMS_BE.Domain.Specifications;
using CMS_BE.Domain.Specifications.Builders;

namespace CMS_BE.Domain.Aggregates.Humans.Specifications
{
    public class GetPatientDetailSpecification : Specification<Patient>
    {
        public GetPatientDetailSpecification(Ulid id)
        {
            Query.Where(patient => patient.Id == id).Include(x => x.Visits).Include(x => x.Contact);
        }
    }
}
