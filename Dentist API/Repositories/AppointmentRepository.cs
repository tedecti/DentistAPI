using Dentist_API.Config;
using Dentist_API.Models;
using Dentist_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Puppy.Dtos.Response.Appointment;

namespace Dentist_API.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<Appointment> CreateAppointment(AppointmentRequestDTO requestDto, int userId, int dentistId)
         {
             var newAppointment = new Appointment
             {
                 UserId = userId,
                 AppointmentDate = requestDto.AppointmentDate,
                 DentistId = dentistId
             };
             _context.Add(newAppointment);
             await _context.SaveChangesAsync();
             return newAppointment;
         }
}