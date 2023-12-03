using Dentist_API.Models;
using Puppy.Dtos.Request.Dentist;

namespace Dentist_API.Repositories.Interfaces;

public interface IDentistRepository
{
    public Task<Dentist> GetDentists();
    public Task<Dentist> GetDentist(int dentistId);
    public Task<Dentist> CreateDentist(DentistRequestDTO requestDto);
}