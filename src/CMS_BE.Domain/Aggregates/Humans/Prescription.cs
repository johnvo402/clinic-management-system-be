using CMS_BE.Domain.Aggregates.Materials;
using CMS_BE.Domain.Common;

namespace CMS_BE.Domain.Aggregates.Humans
{
    public class Prescription : DefaultEntity
    {
        public Ulid VisitId { get; set; } // Khóa ngoại đến Visits
        public Ulid DrugId { get; set; } // Khóa ngoại đến Drugs
        public string? Dosage { get; set; } // Liều lượng (e.g., "2 viên/ngày")
        public int Quantity { get; set; } // Số lượng thuốc
        public Ulid UnitId { get; set; } // Khóa ngoại đến Units
        public Visit Visit { get; set; } = default!;
        public Drug Drug { get; set; } = default!;
        public Unit Unit { get; set; } = default!;
    }
}
