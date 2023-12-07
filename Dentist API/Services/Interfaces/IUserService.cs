using Dentist_API.Models;

namespace Puppy.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUser(int userId);
}