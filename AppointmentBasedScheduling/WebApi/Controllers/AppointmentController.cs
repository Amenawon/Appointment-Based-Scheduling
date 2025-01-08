using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<Appointment> Get(int id)
        {
            return await _appointmentData.GetAppointmentByIdAsync(id);
        }

        [HttpPost]
        public async Task Post(Appointment appointment)
        {
            await _appointmentData.AddAppointmentAsync(appointment);
        }
    }
}
