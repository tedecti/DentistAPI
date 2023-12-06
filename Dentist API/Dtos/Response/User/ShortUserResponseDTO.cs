using Dentist_API.Models;

namespace Dentist_API.Dtos.Response.User;

public class ShortUserResponseDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Gender Gender { get; set; }
}