using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_BE.Domain.Aggregates.Humans;

namespace CMS_BE.Application.Features.Humans.Patients.Commands.Create
{
    public static class CreatePatientMapping
    {
        public static Patient ToEntity(this CreatePatientCommand command)
        {
            return new Patient(command.FullName!, command.Age, command.Gender, command.Note);
        }
    }
}
