using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Dentist_API.Config;
using Dentist_API.Dtos;
using Dentist_API.Dtos.Response;
using Dentist_API.Dtos.Response.User;
using Dentist_API.Models;
using Dentist_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace Dentist_API.Repositories;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly string secret;

    public UserRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        secret = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public async Task<UserResponseDTO> GetUser(int userId)
    {
        var user = _context.Users.Where(u => u.Id == userId);
        var response = _mapper.Map<UserResponseDTO>(user);
        return response;
    }

    public bool isUnique(string phone)
    {
        var userPhone = _context.Users.FirstOrDefault(u => u.Phone == phone);
        return userPhone == null;
    }
    public async Task<User> Register(RegisterRequestDTO registerRequestDto)
    {
        var password = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password, 12);
        var newUser = new User()
        {
            Name = registerRequestDto.Name,
            Surname = registerRequestDto.Name,
            Password = password,
            Birthdate = registerRequestDto.Birthdate,
            GenderId = registerRequestDto.GenderId,
            Phone = registerRequestDto.Phone
        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        newUser.Password = "";

        return newUser;
    }

    public async Task<LoginResponseDTO> Login(LoginRequestDTO loginDto)
    {
        var err = new LoginResponseDTO()
        {
            Token = ""
        };
        var user = _context.Users.FirstOrDefault(u => u.Phone == loginDto.Phone);
        if (user == null)
        {
            return err;
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            return err;
        }

        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var descriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "User")
            }),
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = handler.CreateToken(descriptor);
        LoginResponseDTO loginResponse = new LoginResponseDTO()
        {
            Token = handler.WriteToken(token)
        };
        return loginResponse;
    }
}