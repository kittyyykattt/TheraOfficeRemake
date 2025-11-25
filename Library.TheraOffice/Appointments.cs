namespace TheraOffice.Models;

public class Appointments(
    string Id,
    string PatientId,
    DateTime Start,
    DateTime End,
    string Reason,
    string Physician 
);
