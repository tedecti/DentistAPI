namespace Dentist_API.Models;

public class Appointment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int DentistId { get; set; }
    public Dentist Dentist { get; set; }
    public DateTime AppointmentDate { get; set; }
}