using System.Collections.ObjectModel;

namespace CMS_BE.Application.Features.Humans.Common.Projections.Visits
{
    public class VisitModel
    {
        public string Symptoms { get; set; } = default!;
        public string Diagnosis { get; set; } = default!;
        public string? Note { get; set; }

        public ICollection<PrescriptionModel> PrescriptionModel { get; set; } = [];
    }
}
