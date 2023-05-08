using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HB.Models
{
    public class Patient
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_of_Birth { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
