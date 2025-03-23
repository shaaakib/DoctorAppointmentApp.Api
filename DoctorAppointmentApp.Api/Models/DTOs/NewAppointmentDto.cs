using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentApp.Api.Models.DTOs
{
    public class NewAppointmentDto
    {
        public int patientId { get; set; }
        [Required]
        public string patientName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        [Required]
        public string city { get; set; } = string.Empty;
        [Required]
        public string mobileNo { get; set; } = string.Empty;
        [Required]
        public string address { get; set; } = string.Empty;
        public DateTime appointmentDate { get; set; }
    }
}
