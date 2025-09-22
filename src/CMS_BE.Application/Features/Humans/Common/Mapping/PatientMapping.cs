using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Common.Mapping
{
    public class PatientMapping
    {
        public static PatientDetailProjection ToPatientDetailProjection(Patient patient)
        {
            var projection = new PatientDetailProjection();
            projection.MappingFrom(patient);
            return projection;
        }
    }
}
