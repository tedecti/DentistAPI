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
using Puppy.Services.Interfaces;

namespace Dentist_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userId = Convert.ToInt32(HttpContext.User.Identity.Name);
            var user = await _service.GetUser(userId);
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
            var user = await _service.GetUser(userId);
            var response = _mapper.Map<UserResponseDTO>(user);
            return Ok(response);
        }
    }
}