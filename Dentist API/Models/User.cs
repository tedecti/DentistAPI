namespace Dentist_API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public int GenderId { get; set; }
}