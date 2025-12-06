using TheraOffice.Models;

namespace TheraOffice.Services;

public interface IPatientService
{
    Task<IReadOnlyList<Patient>> GetAllAsync();
    Task<Patient?> GetAsync(Guid id);
    Task<Patient> CreateAsync(Patient patient);
    Task<Patient> UpdateAsync(Patient patient);
    Task<bool> DeleteAsync(Guid id);
}
