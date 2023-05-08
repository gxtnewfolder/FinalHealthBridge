using System.ComponentModel.DataAnnotations;

namespace FinalHealthBridge.Models
{
    public class Test_Result
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public string? TestName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime TestDate { get; set; }
        [Required]
        public string? Result { get; set; }
    }
}
