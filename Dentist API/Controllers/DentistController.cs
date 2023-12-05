using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentist_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puppy.Dtos.Request.Dentist;

namespace Dentist_API.Controllers
{
    [Route("api/dentist")]
    [ApiController]
    public class DentistController : ControllerBase
    {
        private readonly IDentistRepository _repository;
        private readonly IMapper _mapper;

        public DentistController(IDentistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetDentists()
        {
            var dentists = await _repository.GetDentists();
            var dto = _mapper.Map<IEnumerable<DentistResponseDTO>>(dentists);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDentist(int id)
        {
            var dentist = await _repository.GetDentist(id);
            var dto = _mapper.Map<DentistResponseDTO>(dentist);
            return Ok(dto);
        }
        
        [HttpPost]
        [Authorize]
        // soon change it to roles and add from the admin panel
        public async Task<IActionResult> PostDentist([FromBody] DentistRequestDTO requestDto)
        {
            await _repository.CreateDentist(requestDto);
            return StatusCode(201);
        }
    }
}
