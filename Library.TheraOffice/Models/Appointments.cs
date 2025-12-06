namespace TheraOffice.Models;

public class Appointment
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid PatientId { get; set; }
    public Guid PhysicianId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End   { get; set; }

    public string Reason { get; set; } = string.Empty;
}
