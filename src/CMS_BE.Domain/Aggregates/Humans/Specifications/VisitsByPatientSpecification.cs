using CMS_BE.Domain.Specifications;
using CMS_BE.Domain.Specifications.Builders;

namespace CMS_BE.Domain.Aggregates.Humans.Specifications
{
    public class VisitsByPatientSpecification : Specification<Visit>
    {
        public VisitsByPatientSpecification(Ulid patientId)
        {
            Query.Where(v => v.PatientId == patientId);
        }
    }
}
