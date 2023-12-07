using Dentist_API.Models;

namespace Puppy.Services.Interfaces;

public interface IAppointmentService
{
    public Task<Appointment> GetAppointment(int userId);
}