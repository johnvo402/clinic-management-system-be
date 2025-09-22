using CMS_BE.Domain.Common;

namespace CMS_BE.Domain.Aggregates.Materials
{
    public class Unit : DefaultEntity
    {
        public Ulid DrugId { get; set; }
        public string Name { get; set; } = default!;
        public int Multiple { get; set; } = 1;
        public Drug Drug { get; set; } = default!;
    }
}
