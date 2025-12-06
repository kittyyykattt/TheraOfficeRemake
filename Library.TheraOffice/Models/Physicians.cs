namespace TheraOffice.Models;

public class Physician
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName  { get; set; } = string.Empty;

    public string LicenseNumber { get; set; } = string.Empty;
    public DateOnly GraduationDate { get; set; }

    public List<string> Specializations { get; set; } = new();
}

