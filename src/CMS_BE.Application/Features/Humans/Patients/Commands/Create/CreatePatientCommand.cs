using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using Mediator;

namespace CMS_BE.Application.Features.Humans.Patients.Commands
{
    public class CreatePatientCommand : PatientModel, IRequest<Result> { }
}
