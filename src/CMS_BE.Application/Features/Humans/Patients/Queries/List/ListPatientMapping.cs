using System.Linq.Expressions;

namespace CMS_BE.Application.Features.Humans.Patients.Queries.List
{
    public static class ListPatientMapping
    {
        public static Expression<
            Func<Domain.Aggregates.Humans.Patient, ListPatientResponse>
        > Selector()
        {
            return patient => new ListPatientResponse
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Age = patient.Age,
                Gender = patient.Gender,
                NumberVisits = patient.Visits.Count,
            };
        }
    }
}
