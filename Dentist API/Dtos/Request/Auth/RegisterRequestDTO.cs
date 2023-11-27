using Dentist_API.Models;

namespace Dentist_API.Dtos;

public class RegisterRequestDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public DateTime Birthdate { get; set; }
    public string Phone { get; set; }
    public int GenderId { get; set; }
}