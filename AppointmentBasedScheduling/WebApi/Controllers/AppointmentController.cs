using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentData _appointmentData;

        public AppointmentController(IAppointmentData appointmentData)
        {
            _appointmentData = appointmentData;
        }

        [HttpGet]
        public List<AppointmentModel> Get()
        {
            return _appointmentData.GetAppointment();
        }

        [HttpPost]
        public void Post(AppointmentModel appointment)
        {
            _appointmentData.SaveInventoryRecord(appointment);
        }
    }
}
