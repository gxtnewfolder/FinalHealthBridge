namespace FinalHealthBridge.Models
{
    public class Medical_History
    {
        public int Id { get; set; }
        public long PatientId { get; set; }
        public string? Diagnosis { get; set; }
        public string? chronic_diseases { get; set; }
        public string? allergies { get; set; }
    }
}
