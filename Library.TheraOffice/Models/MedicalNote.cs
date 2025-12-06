namespace TheraOffice.Models;

public class MedicalNote
{
    public Guid Id{get; set; } = Guid.NewGuid();
    public Guid PatientId{get; set;}
    public Guid PhysicianId{get; set;}
    public DateTime CreatedAt {get; set; } = DateTime.Now;
    public string Diagnosis {get; set; } = string.Empty;
    public string Prescription {get; set; } = string.Empty;
    public string Notes {get; set;} = string.Empty;
}