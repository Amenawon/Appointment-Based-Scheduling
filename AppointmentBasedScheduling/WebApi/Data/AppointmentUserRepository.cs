using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppointmentUserRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAppointmentUserAsync(AppointmentUser appointmentUser)
        {
            _context.AppointmentUsers.Add(appointmentUser);
            await _context.SaveChangesAsync();
        }
    }
}
