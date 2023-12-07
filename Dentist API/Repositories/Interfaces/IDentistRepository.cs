using Dentist_API.Models;
using Puppy.Dtos.Request.Dentist;

namespace Dentist_API.Repositories.Interfaces;

public interface IDentistRepository
{
    public Task<Dentist> CreateDentist(DentistRequestDTO requestDto);
}