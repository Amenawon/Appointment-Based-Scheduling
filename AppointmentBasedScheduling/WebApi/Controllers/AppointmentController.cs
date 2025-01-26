using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentData;
        private readonly AppointmentUserRepository _appointmentUserData;

        public AppointmentController(AppointmentRepository appointmentData, AppointmentUserRepository appointmentUserData)
        {
            _appointmentData = appointmentData;
            _appointmentUserData = appointmentUserData;
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
            // Remove AppointmentUsers temporarily
            var appointmentUsers = appointment.AppointmentUsers;
            appointment.AppointmentUsers = null;

            await _appointmentData.AddAppointmentAsync(appointment);

            if (appointmentUsers != null)
            {
                // Populate AppointmentId in AppointmentUsers
                foreach (var appointmentUser in appointmentUsers)
                {
                    appointmentUser.AppointmentId = appointment.Id; // Assign the AppointmentId
                    await _appointmentUserData.AddAppointmentUserAsync(appointmentUser);
                }
            }

            return Ok("Appointment created successfully.");
        }
    }
}
