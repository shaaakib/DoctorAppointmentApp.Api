using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointmentApp.Api.Models
{
    [Table("patients")]
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
