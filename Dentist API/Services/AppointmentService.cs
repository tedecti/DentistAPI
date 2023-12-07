using Dentist_API.Config;
using Dentist_API.Models;
using Microsoft.EntityFrameworkCore;
using Puppy.Services.Interfaces;

namespace Puppy.Services;

public class AppointmentService : IAppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Appointment> GetAppointment(int userId)
    {
        var appointment = await _context.Appointments.Include(a => a.User).Include(a => a.Dentist)
            .Include(a => a.User.Gender).Where(a => a.UserId == userId).FirstOrDefaultAsync();
        return appointment;
    }
}
