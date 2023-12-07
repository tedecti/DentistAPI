using Dentist_API.Config;
using Dentist_API.Models;
using Microsoft.EntityFrameworkCore;
using Puppy.Services.Interfaces;

namespace Puppy.Services;

public class DentistService : IDentistService
{
    private readonly AppDbContext _context;

    public DentistService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Dentist>> GetDentists()
    {
        var dentists = await _context.Dentists.ToListAsync();
        return dentists;
    }

    public async Task<Dentist> GetDentist(int dentistId)
    {
        var dentist = await _context.Dentists.Where(d => d.Id == dentistId).FirstOrDefaultAsync();
        return dentist;
    }
}