namespace Dentist_API.Dtos.Response.User;

public class UserResponseDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public DateTime Birthdate { get; set; }
    public string Phone { get; set; }   
    public int GenderId { get; set; }
}