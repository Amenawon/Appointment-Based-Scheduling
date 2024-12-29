using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentData _appontmentData;

        public AppointmentController(IAppointmentData appontmentData)
        {
            _appontmentData = appontmentData;
        }

        [HttpGet]
        public List<AppointmentModel> Get()
        {
            return _appontmentData.GetAppointment();
        }

        [HttpPost]
        public void Post(AppointmentModel appointment)
        {
            _appontmentData.SaveInventoryRecord(appointment);
        }
    }
}
