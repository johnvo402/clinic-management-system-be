using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.Detail
{
    public static class PatientDetailMapping
    {
        public static PatientDetailResponse ToResponse(this Patient patient)
        {
            var response = new PatientDetailResponse();
            response.MappingFrom(patient);
            return response;
        }
    }
}
