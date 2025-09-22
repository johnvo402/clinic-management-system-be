using CMS_BE.Application.Utils;
using CMS_BE.Domain.Aggregates.Materials;

namespace CMS_BE.Application.Features.Materials.Drugs.Commands.Create
{
    public static class CreateDrugMapping
    {
        public static Drug ToEntity(this CreateDrugCommand command)
        {
            var code = command.Code?.Trim();
            if (string.IsNullOrEmpty(code))
            {
                code = StringUtil.GenerateCode("DR", 6);
            }
            var drug = new Drug(code, command.Name, command.Price);
            return drug;
        }
    }
}
