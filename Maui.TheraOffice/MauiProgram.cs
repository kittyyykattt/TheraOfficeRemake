using Library.TheraOffice;         
using TheraOffice.Services;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<IPatientService, InMemoryPatientService>();
        builder.Services.AddTransient<PatientsViewModel>();
        builder.Services.AddTransient<PatientsPage>();
        builder.Services.AddSingleton<IPhysicianService, InMemoryPhysicianService>();
        builder.Services.AddSingleton<IAppointmentService, InMemoryAppointmentService>();

        return builder.Build();
    }
}
