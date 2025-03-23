using DoctorAppointmentApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApp.Api.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
