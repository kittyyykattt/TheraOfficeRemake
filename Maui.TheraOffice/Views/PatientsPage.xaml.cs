using TheraOffice.Models;
using Maui.TheraOffice.ViewModels;
using TheraOffice.Services;

namespace Maui.TheraOffice.Views;

public partial class PatientsPage : ContentPage
{
    public PatientsPage(PatientsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
