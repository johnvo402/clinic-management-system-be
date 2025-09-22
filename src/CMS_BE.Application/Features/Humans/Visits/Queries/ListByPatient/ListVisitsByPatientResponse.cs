using System.Text.Json.Serialization;
using CMS_BE.Application.Common.DTOs.Responses;

namespace CMS_BE.Application.Features.Humans.Visits.Queries.ListByPatient
{
    public class ListVisitsByPatientResponse : BaseResponse
    {
        public Ulid PatientId { get; set; }
        public DateTimeOffset VisitDate { get; set; }
        public string Symptoms { get; set; } = default!;
        public string Diagnosis { get; set; } = default!;
        public string? Note { get; set; }
    }
}
