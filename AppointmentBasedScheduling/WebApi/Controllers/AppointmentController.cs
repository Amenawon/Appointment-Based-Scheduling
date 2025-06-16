using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.AppointmentDetails;
using WebApi.Models.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentData;
        private readonly AppointmentUserRepository _appointmentUserData;
        private readonly UserManager<User> _userManager;

        public AppointmentController(AppointmentRepository appointmentData,
            AppointmentUserRepository appointmentUserData,
            UserManager<User> userManager)
        {
            _appointmentData = appointmentData;
            _appointmentUserData = appointmentUserData;
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<Appointment> Get(int id)
        {
            return await _appointmentData.GetAppointmentByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Appointment>> GetAllUserAppointments()
        {
            return await _appointmentData.GetAppointmentsAsync();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Post([FromBody] AppointmentModel appointmentDto)
        {

            var user = await _userManager.FindByEmailAsync(appointmentDto.OrganiserEmail);
            if (user == null)
            {
                return NotFound("OrganiserId not found.");
            }

            var appointment = new Appointment
            {
                Title = appointmentDto.Title,
                Description = appointmentDto.Description,
                Date = appointmentDto.Date,
                Duration = appointmentDto.Duration,
                Location = appointmentDto.Location,
                Status = appointmentDto.Status,
                OrganiserId = user.Id
            };

            await _appointmentData.AddAppointmentAsync(appointment);

            foreach (AppointmentUserModel attendeeDto in appointmentDto.ListAttendees)
            {
                var appointmentUser = new AppointmentUser();
                var attendee = await _userManager.FindByEmailAsync(attendeeDto.AttendeeEmail);

                if (attendee is not null)
                {
                    appointmentUser = new AppointmentUser
                    {
                        AppointmentId = appointment.Id,
                        UserId = attendee.Id,
                        Role = attendeeDto.Role,
                        RsvpStatus = attendeeDto.RsvpStatus
                    };
                }
                else
                {
                    var placeholderUser = new User
                    {
                        UserName = "Unknown",
                        Email = attendeeDto.AttendeeEmail,
                        FirstName = "Unknown",
                        LastName = "Unknown",
                        Organisation = "Unknown",
                        IsPlaceholder = true
                    };

                    await _userManager.CreateAsync(placeholderUser);
                    var attendeeUserId = placeholderUser.Id;

                    appointmentUser = new AppointmentUser
                    {
                        AppointmentId = appointment.Id,
                        UserId = attendeeUserId,
                        Role = attendeeDto.Role,
                        RsvpStatus = attendeeDto.RsvpStatus
                    };
                }

                await _appointmentUserData.AddAppointmentUserAsync(appointmentUser);
            }

            return Ok("Appointment created successfully.");
        }
    }
}
