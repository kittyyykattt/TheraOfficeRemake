namespace Library.TheraOffice;

public class Patient
{
        public string? Name { get; set; }
        public string? Address {  get; set; }
        public string? BirthDate {  get; set; }
        public string? Race {  get; set; }
        public string? Gender {  get; set; }
        public string? Notes {  get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
             return $"{Id}. {Name} ({Gender}, {Race}) - DOB: {BirthDate}, Address: {Address}, Notes: {Notes}";
        }

    }
public class Physician
{
    public string? Name { get; set; }
    public string? License { get; set; }
    public string? GraduationDate { get; set; }
    public string? Special { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
         return $"{Id}. Dr. {Name} - License: {License}, Graduated: {GraduationDate}, Specialization: {Special}";
    }

}

public class Appointment
{
    public string? Day { get; set; }
    public string? Time { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{Id}. Appointment on {Day} at {Time}:00";
    }

}


