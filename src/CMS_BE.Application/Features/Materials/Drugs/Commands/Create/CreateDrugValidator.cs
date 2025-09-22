using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Application.Features.Materials.Common.Projections;
using CMS_BE.Application.Features.Materials.Common.Validators;
using FluentValidation;

namespace CMS_BE.Application.Features.Materials.Drugs.Commands.Create
{
    public class CreateDrugValidator : AbstractValidator<CreateDrugCommand>
    {
        public CreateDrugValidator()
        {
            Include(new DrugValidator());
        }
    }
}
