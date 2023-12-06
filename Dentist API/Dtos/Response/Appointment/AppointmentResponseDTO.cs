using Dentist_API.Dtos.Response.User;
using Dentist_API.Models;

namespace Puppy.Dtos.Response.Appointment;

public class AppointmentResponseDTO
{
    public ShortUserResponseDTO User { get; set; }
    public Dentist Dentist { get; set; }
    public DateTime AppointmentDate { get; set; }
}