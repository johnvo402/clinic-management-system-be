using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Application.Common.Extensions;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Visits.Commands.Create
{
    public static class CreateVisitMapping
    {
        public static Visit ToEntity(this CreateVisitCommand command)
        {
            var visit = new Visit
            {
                VisitDate = DateTimeOffset.UtcNow,
                Symptoms = command.Model.Symptoms,
                Diagnosis = command.Model.Diagnosis,
                Note = command.Model.Note,
            };

            visit.Prescriptions = command
                .Model.PrescriptionModel.Select(x => new Prescription
                {
                    Dosage = x.Dosage,
                    Quantity = x.Quantity,
                    DrugId = Ulid.Parse(x.DrugId),
                    UnitId = Ulid.Parse(x.UnitId),
                })
                .ToListIfNot();

            return visit;
        }
    }
}
