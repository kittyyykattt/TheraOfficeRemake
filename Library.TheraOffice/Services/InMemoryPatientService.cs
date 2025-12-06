using TheraOffice.Models;

namespace TheraOffice.Services;

public class InMemoryPatientService : IPatientService
{
    private readonly Dictionary<Guid, Patient> _store = new();

    public Task<IReadOnlyList<Patient>> GetAllAsync() =>
        Task.FromResult((IReadOnlyList<Patient>)_store.Values.ToList());

    public Task<Patient?> GetAsync(Guid id)
    {
        _store.TryGetValue(id, out var patient);
        return Task.FromResult(patient);
    }

    public Task<Patient> CreateAsync(Patient patient)
    {
        if (patient.Id == Guid.Empty)
            patient.Id = Guid.NewGuid();

        _store[patient.Id] = patient;
        return Task.FromResult(patient);
    }

    public Task<Patient> UpdateAsync(Patient patient)
    {
        _store[patient.Id] = patient;
        return Task.FromResult(patient);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removed = _store.Remove(id);
        return Task.FromResult(removed);
    }
}
