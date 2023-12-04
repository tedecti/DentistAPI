using Dentist_API.Config;
using Dentist_API.Models;
using Dentist_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Puppy.Dtos.Request.Dentist;

namespace Dentist_API.Repositories;

public class DentistRepository : IDentistRepository
{
    private readonly AppDbContext _context;

    public DentistRepository(AppDbContext context)
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

    public async Task<Dentist> CreateDentist(DentistRequestDTO requestDto)
    {
        var newDentist = new Dentist()
        {
            Name = requestDto.Name,
            Description = requestDto.Description,
            Experience = requestDto.Experience
        };
        _context.Add(newDentist);
        await _context.SaveChangesAsync();
        return newDentist;
    }
}