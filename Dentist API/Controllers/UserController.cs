using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentist_API.Dtos.Response.User;
using Dentist_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentist_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var user = await _repository.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<UserResponseDTO>(user);
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _repository.GetUser(userId);
            var response = _mapper.Map<UserResponseDTO>(user);
            return Ok(response);
        }
    }
}