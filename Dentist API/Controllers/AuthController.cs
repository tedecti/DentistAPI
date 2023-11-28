using Dentist_API.Config;
using Dentist_API.Dtos;
using Dentist_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dentist_API.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;
    
    public AuthController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
    {
        if (!_repository.isUnique(registerRequestDto.Phone))
        {
            return BadRequest("Password is not unique");
        }
        await _repository.Register(registerRequestDto);
        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
    {
        var response = await _repository.Login(loginRequestDto);
        
        if (string.IsNullOrEmpty(response.Token))
        {
            return BadRequest(new { message = "Email or password incorrect" });
        }
        
        return Ok(response);
    }
}