using StudentsManagement.ViewModels;

namespace StudentsManagement.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView()
	{
		InitializeComponent();

        BindingContext = new SettingsViewModel();
    }

    private async void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        await Shell.Current.GoToAsync("///StudentListView");
    }
}