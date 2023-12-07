using Dentist_API.Models;

namespace Puppy.Services.Interfaces;

public interface IDentistService
{
    public Task<List<Dentist>> GetDentists();
    public Task<Dentist> GetDentist(int dentistId);
}