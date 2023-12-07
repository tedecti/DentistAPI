using Dentist_API.Dtos;
using Dentist_API.Dtos.Response;
using Dentist_API.Dtos.Response.User;
using Dentist_API.Models;

namespace Dentist_API.Repositories.Interfaces;

public interface IUserRepository
{
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
    Task<User> Register(RegisterRequestDTO registerRequestDto);
    bool isUnique(string phone);
}