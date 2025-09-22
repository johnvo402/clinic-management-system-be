namespace CMS_BE.Application.Features.Humans.Common.Projections.Visits
{
    public class PrescriptionModel
    {
        public string? DrugId { get; set; }
        public string? Dosage { get; set; }
        public int Quantity { get; set; }
        public string? UnitId { get; set; }
    }
}
