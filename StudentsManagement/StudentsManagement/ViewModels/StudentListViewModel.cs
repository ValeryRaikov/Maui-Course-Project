using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Views;

namespace StudentsManagement.ViewModels
{
    public partial class StudentListViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentView));
        }
    }
}
