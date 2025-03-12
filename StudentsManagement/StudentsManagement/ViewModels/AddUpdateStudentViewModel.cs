using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Data;
using StudentsManagement.Services;
using System.Threading.Tasks;

namespace StudentsManagement.ViewModels
{
    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        public AddUpdateStudentViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            var response = await _studentService.AddStudent(new StudentEntity
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
            });

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Record Added!", "Record Added to Students List.", "OK");
            } 
            else
            {
                await Shell.Current.DisplayAlert("Not Added!", "Something went wrong while adding record!", "OK");
            }
        }
    }
}
