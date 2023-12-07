using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentist_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puppy.Dtos.Response.Appointment;
using Puppy.Services.Interfaces;

namespace Dentist_API.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _repository;
        private readonly IAppointmentService _service;

        public AppointmentController(IMapper mapper, IAppointmentRepository repository, IAppointmentService service)
        {
            _mapper = mapper;
            _repository = repository;
            _service = service;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAppointment()
        {
            var user = Convert.ToInt32(HttpContext.User.Identity.Name);
            var response = await _service.GetAppointment(user);
            var mappedResponse = _mapper.Map<AppointmentResponseDTO>(response);
            return Ok(mappedResponse);
        }

        [HttpPost("{dentistId}")]
        [Authorize]
        public async Task<IActionResult> PostAppointment([FromBody] AppointmentRequestDTO appointmentRequestDto, int dentistId)
        {
            var user = Convert.ToInt32(HttpContext.User.Identity.Name);
            await _repository.CreateAppointment(appointmentRequestDto, user, dentistId);
            return StatusCode(201);
        }
    }
}
