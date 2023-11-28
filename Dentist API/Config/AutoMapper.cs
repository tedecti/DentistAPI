using AutoMapper;
using Dentist_API.Dtos.Response;
using Dentist_API.Dtos.Response.User;
using Dentist_API.Models;

namespace Dentist_API.Config;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<User, UserResponseDTO>();
    }
}