using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppointmentApp.Api.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int appointmentId { get; set; }
        [Required]
        public int patientId { get; set; }
        [Required]
        public DateTime appointmentDate { get; set; }
        [Required]
        public bool isDone { get; set; }
        [Required]
        public Nullable<float> fees { get; set; }
    }
}
