namespace CMS_BE.Domain.Specifications.Models
{
    public class IncludeInfo : ExpressionInfo
    {
        public InCludeType InCludeType { get; set; }
        public Type? PreviousPropertyType { get; set; }
    }
}
