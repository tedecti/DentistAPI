using Dentist_API.Config;
using Dentist_API.Models;
using Microsoft.EntityFrameworkCore;
using Puppy.Services.Interfaces;

namespace Puppy.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUser(int userId)
    {
        var user = await _context.Users.Include(u=>u.Gender).Where(u => u.Id == userId).FirstOrDefaultAsync();
        return user;
    }
}