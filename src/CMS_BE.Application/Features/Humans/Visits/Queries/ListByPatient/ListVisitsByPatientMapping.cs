using System.Linq.Expressions;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Visits.Queries.ListByPatient
{
    public static class ListVisitsByPatientMapping
    {
        public static Expression<Func<Visit, ListVisitsByPatientResponse>> Selector()
            => v => new ListVisitsByPatientResponse
            {
                Id = v.Id,
                PatientId = v.PatientId,
                VisitDate = v.VisitDate,
                Symptoms = v.Symptoms,
                Diagnosis = v.Diagnosis,
                Note = v.Note,
            };
    }
}



