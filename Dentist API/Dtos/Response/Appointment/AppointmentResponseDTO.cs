using Dentist_API.Models;

namespace Puppy.Dtos.Response.Appointment;

public class AppointmentResponseDTO
{
    public User User { get; set; }
    public Dentist Dentist { get; set; }
    public DateTime AppointmentDate { get; set; }
}