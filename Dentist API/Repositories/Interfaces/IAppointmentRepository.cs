using Dentist_API.Models;
using Puppy.Dtos.Response.Appointment;

namespace Dentist_API.Repositories.Interfaces;

public interface IAppointmentRepository
{
    public Task<Appointment> GetAppointment(int userId);
    public Task<Appointment> CreateAppointment(AppointmentRequestDTO requestDto, int userId, int dentistId);
}