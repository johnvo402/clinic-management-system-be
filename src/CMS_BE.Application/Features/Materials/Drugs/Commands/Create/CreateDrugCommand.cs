using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Materials.Common.Projections;
using Mediator;

namespace CMS_BE.Application.Features.Materials.Drugs.Commands.Create
{
    public class CreateDrugCommand : DrugModel, ICommand<Result>;
}
