using TheraOffice.Models;

namespace TheraOffice.Services;

public class InMemoryAppointmentService : AppointmentService
{
    private readonly Dictionary<string, Appointment> _store = new();

    public Task<Appointment> CreateAsync(Appointment appt)
    {
        var id = appt.Id == string.Empty ? string.NewString() : appt.Id;
        var created = appt with { Id = id };
        _store[id] = created;
        return Task.FromResult(created);
    }

    public Task<Appointment?> GetAsync(string id) =>
        Task.FromResult(_store.TryGetValue(id, out var a) ? a : null);

    public Task<IReadOnlyList<Appointment>> ListAsync(DateOnly day)
    {
        var items = _store.Values
            .Where(a => DateOnly.FromDateTime(a.Start) == day)
            .OrderBy(a => a.Start)
            .ToList()
            .AsReadOnly();
        return Task.FromResult((IReadOnlyList<Appointment>)items);
    }

    public Task<bool> DeleteAsync(string id) =>
        Task.FromResult(_store.Remove(id));
}

