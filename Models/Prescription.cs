namespace FinalHealthBridge.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public long PatientId { get; set; }
        public string? Medication_Name { get; set; }
        public string? Dosage { get; set; }
    }
}
