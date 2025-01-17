﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentData;

        public AppointmentController(AppointmentRepository appointmentData)
        {
            _appointmentData = appointmentData;
        }


        [HttpGet("{id}")]
        public async Task<Appointment> Get(int id)
        {
            return await _appointmentData.GetAppointmentByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Appointment>> Get()
        {
            return await _appointmentData.GetAppointmentsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Appointment appointment)
        {
            await _appointmentData.AddAppointmentAsync(appointment);

            return Ok("Appointment created successfully.");
        }
    }
}
