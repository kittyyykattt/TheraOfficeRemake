using System.Runtime.CompilerServices;

namespace TheraOffice.Models;

public enum Gender
{
    Unknown, Female, Male, NonBinary, Other
}
public enum Race
{
    Unknown, White, Black, Asian, Hispanic, NativeAmerican, Other
}
public class Patient{
    public Guid Id {get; set;} = Guid.NewGuid();

    public string FirstName{get; set; } = string.Empty;
    public string LastName {get; set; } = string.Empty;
    public string Address { get; set; }= string.Empty;

    public DateOnly BirthDate { get; set;}

    public Race Race {get; set;} = Race.Unknown;
    public Gender Gender {get; set; } = Gender.Unknown;
    public List<MedicalNote> Notes { get; set;} = new();
}
