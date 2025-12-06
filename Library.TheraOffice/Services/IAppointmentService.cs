using TheraOffice.Models;

namespace TheraOffice.Services;

public interface IAppointmentService
{
    Task<IReadOnlyList<Appointment>> GetAllAsync();
    Task<Appointment?> GetAsync(Guid id);
    Task<Appointment> CreateAsync(Appointment appointment);
    Task<Appointment> UpdateAsync(Appointment appointment);
    Task<bool> DeleteAsync(Guid id);
}

