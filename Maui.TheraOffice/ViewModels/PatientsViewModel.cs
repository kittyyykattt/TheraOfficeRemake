using System.Collections.ObjectModel;
using System.Windows.Input;
using TheraOffice.Models;
using TheraOffice.Services;

namespace Maui.TheraOffice.ViewModels;

public class PatientsViewModel : BindableObject
{
    private readonly IPatientService _patientService;

    public ObservableCollection<Patient> Patients { get; } = new();

    // Form fields
    private Patient? _selected;
    public Patient? Selected
    {
        get => _selected;
        set
        {
            if (_selected == value) return;
            _selected = value;
            OnPropertyChanged();

            if (value != null)
            {
                FirstName = value.FirstName;
                LastName  = value.LastName;
                Address   = value.Address;
                BirthDate = value.BirthDate.ToDateTime(TimeOnly.MinValue);
                SelectedGender = value.Gender;
                SelectedRace   = value.Race;
            }
        }
    }

    public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
    private string _firstName = string.Empty;

    public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
    private string _lastName = string.Empty;

    public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }
    private string _address = string.Empty;

    public DateTime BirthDate { get => _birthDate; set { _birthDate = value; OnPropertyChanged(); } }
    private DateTime _birthDate = DateTime.Today;

    public IList<Gender> Genders { get; } = Enum.GetValues<Gender>().ToList();
    public IList<Race> Races { get; } = Enum.GetValues<Race>().ToList();

    public Gender SelectedGender { get => _selectedGender; set { _selectedGender = value; OnPropertyChanged(); } }
    private Gender _selectedGender = Gender.Unknown;

    public Race SelectedRace { get => _selectedRace; set { _selectedRace = value; OnPropertyChanged(); } }
    private Race _selectedRace = Race.Unknown;

    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand DeleteCommand { get; }

    public PatientsViewModel(IPatientService patientService)
    {
        _patientService = patientService;

        AddCommand    = new Command(async () => await AddAsync());
        UpdateCommand = new Command(async () => await UpdateAsync(), () => Selected != null);
        DeleteCommand = new Command(async () => await DeleteAsync(), () => Selected != null);

        _ = LoadAsync();
    }

    private async Task LoadAsync()
    {
        Patients.Clear();
        var all = await _patientService.GetAllAsync();
        foreach (var p in all) Patients.Add(p);
    }

    private async Task AddAsync()
    {
        var patient = new Patient
        {
            FirstName = FirstName,
            LastName  = LastName,
            Address   = Address,
            BirthDate = DateOnly.FromDateTime(BirthDate),
            Gender    = SelectedGender,
            Race      = SelectedRace
        };

        var created = await _patientService.CreateAsync(patient);
        Patients.Add(created);
    }

    private async Task UpdateAsync()
    {
        if (Selected is null) return;

        Selected.FirstName = FirstName;
        Selected.LastName  = LastName;
        Selected.Address   = Address;
        Selected.BirthDate = DateOnly.FromDateTime(BirthDate);
        Selected.Gender    = SelectedGender;
        Selected.Race      = SelectedRace;

        await _patientService.UpdateAsync(Selected);
        await LoadAsync();
    }

    private async Task DeleteAsync()
    {
        if (Selected is null) return;

        await _patientService.DeleteAsync(Selected.Id);
        await LoadAsync();
    }
}
