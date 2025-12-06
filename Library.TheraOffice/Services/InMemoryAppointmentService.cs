using TheraOffice.Models;

namespace TheraOffice.Services;

public class InMemoryAppointmentService : IAppointmentService
{
    private readonly Dictionary<Guid, Appointment> _store = new();

    public Task<IReadOnlyList<Appointment>> GetAllAsync() =>
        Task.FromResult((IReadOnlyList<Appointment>)_store.Values
            .OrderBy(a => a.Start)
            .ToList());

    public Task<Appointment?> GetAsync(Guid id)
    {
        _store.TryGetValue(id, out var appt);
        return Task.FromResult(appt);
    }

    public Task<Appointment> CreateAsync(Appointment appointment)
    {
        ValidateAppointment(appointment, appointment.Id);

        if (appointment.Id == Guid.Empty)
            appointment.Id = Guid.NewGuid();

        _store[appointment.Id] = appointment;
        return Task.FromResult(appointment);
    }

    public Task<Appointment> UpdateAsync(Appointment appointment)
    {
        ValidateAppointment(appointment, appointment.Id);

        _store[appointment.Id] = appointment;
        return Task.FromResult(appointment);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removed = _store.Remove(id);
        return Task.FromResult(removed);
    }

    // ---------------------------------
    // VALIDATION: HOURS + DOUBLE-BOOKING
    // ---------------------------------
    private void ValidateAppointment(Appointment appt, Guid currentId)
    {
        // 1. Only Monday–Friday
        if (appt.Start.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            throw new InvalidOperationException("Appointments may only be scheduled Monday–Friday.");

        // 2. Only between 8:00 and 17:00 local time
        var startTime = appt.Start.TimeOfDay;
        var endTime   = appt.End.TimeOfDay;

        var open  = new TimeSpan(8, 0, 0);
        var close = new TimeSpan(17, 0, 0);

        if (startTime < open || endTime > close || appt.End <= appt.Start)
            throw new InvalidOperationException("Appointments must be between 8:00 and 17:00 and have a positive duration.");

        // 3. No double-booking physicians
        bool overlaps(Appointment a, Appointment b) =>
            a.Start < b.End && b.Start < a.End; // standard overlap test

        var samePhysicianAppts = _store.Values
            .Where(a => a.PhysicianId == appt.PhysicianId && a.Id != currentId);

        if (samePhysicianAppts.Any(existing => overlaps(existing, appt)))
            throw new InvalidOperationException("This physician is already booked for that time.");
    }
}
