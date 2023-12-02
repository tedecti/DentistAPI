using Dentist_API.Models;

namespace Puppy.Dtos.Response.Appointment;

public class AppointmentRequestDTO
{
    public int UserId { get; set; }
    public int DentistId { get; set; }
    public DateTime AppointmentDate { get; set; }
}