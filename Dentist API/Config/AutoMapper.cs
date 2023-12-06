using AutoMapper;
using Dentist_API.Dtos.Response;
using Dentist_API.Dtos.Response.User;
using Dentist_API.Models;
using Puppy.Dtos.Request.Dentist;
using Puppy.Dtos.Response.Appointment;

namespace Dentist_API.Config;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<User, UserResponseDTO>();
        CreateMap<Appointment, AppointmentResponseDTO>();
        CreateMap<Dentist, DentistResponseDTO>();
        CreateMap<User, ShortUserResponseDTO>();
    }
}