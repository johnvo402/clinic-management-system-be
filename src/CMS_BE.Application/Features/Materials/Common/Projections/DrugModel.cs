namespace CMS_BE.Application.Features.Materials.Common.Projections
{
    public class DrugModel
    {
        public string? Code { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public List<UnitModel> Units { get; set; } = new List<UnitModel>();
    }

    public class UnitModel
    {
        public string Name { get; set; } = default!;
        public int Multiple { get; set; } = 1;
    }
}
