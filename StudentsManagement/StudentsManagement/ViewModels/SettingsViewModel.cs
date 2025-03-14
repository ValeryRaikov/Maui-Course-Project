using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Views;

namespace StudentsManagement.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isDarkMode;

        public SettingsViewModel()
        {
            IsDarkMode = Preferences.Get("DarkMode", false);
            ApplyTheme(IsDarkMode);
        }

        partial void OnIsDarkModeChanged(bool value)
        {
            Preferences.Set("DarkMode", value);
            ApplyTheme(value);
        }

        private static void ApplyTheme(bool isDark)
        {
            Application.Current.UserAppTheme = isDark ? AppTheme.Dark : AppTheme.Light;
        }
    }
}
