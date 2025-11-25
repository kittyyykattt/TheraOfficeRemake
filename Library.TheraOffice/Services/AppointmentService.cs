using TheraOffice.Models;

namespace TheraOffice.Services;

public interface AppointmentService
{
    Task<Appointment> CreateAsync(Appointment appt);
    Task<Appointment?> GetAsync(Guid id);
    Task<IReadOnlyList<Appointment>> ListAsync(DateOnly day);
    Task<bool> DeleteAsync(Guid id);
}

