using CMS_BE.Domain.Specifications;
using CMS_BE.Domain.Specifications.Builders;

namespace CMS_BE.Domain.Aggregates.Humans.Specifications
{
    public class ListPatientSpecification : Specification<Patient>
    {
        public ListPatientSpecification()
        {
            Query.Include(p => p.Visits);
        }
    }
}
