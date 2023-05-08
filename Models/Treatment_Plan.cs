namespace FinalHealthBridge.Models
{
    public class Treatment_Plan
    {
        public int Id { get; set; }
        public long PatientId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment_Description { get; set; }
    }
}
