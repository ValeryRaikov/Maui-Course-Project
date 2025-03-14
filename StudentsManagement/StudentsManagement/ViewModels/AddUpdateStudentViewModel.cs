using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Data;
using StudentsManagement.Exceptions;
using StudentsManagement.Services;
using StudentsManagement.Views;
using System.Text.RegularExpressions;

namespace StudentsManagement.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentEntity _studentDetail = new StudentEntity();

        private readonly IStudentService _studentService;

        public AddUpdateStudentViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            const string NAME_PATTERN = @"^[A-Za-z\s]{2,50}$";
            const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            try
            {
                if (string.IsNullOrWhiteSpace(StudentDetail.FirstName) || !Regex.IsMatch(StudentDetail.FirstName, NAME_PATTERN))
                {
                    await Shell.Current.DisplayAlert("Validation Error", "First name must contain only letters and be at least 2 characters long.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(StudentDetail.LastName) || !Regex.IsMatch(StudentDetail.LastName, NAME_PATTERN))
                {
                    await Shell.Current.DisplayAlert("Validation Error", "Last name must contain only letters and be at least 2 characters long.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(StudentDetail.Email) || !Regex.IsMatch(StudentDetail.Email, EMAIL_PATTERN))
                {
                    await Shell.Current.DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
                    return;
                }

                int response = -1;
                if (StudentDetail.StudentId > 0)
                {
                    response = await _studentService.UpdateStudent(StudentDetail);
                }
                else
                {
                    response = await _studentService.AddStudent(new StudentEntity
                    {
                        FirstName = StudentDetail.FirstName,
                        LastName = StudentDetail.LastName,
                        Email = StudentDetail.Email,
                    });

                    if (response > 0)
                    {
                        await Shell.Current.DisplayAlert("Student Info Saved!", "Record Saved to Students List.", "OK");
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Not Added!", "Something went wrong while adding record!", "OK");
                    }
                }
            }
            catch (DatabaseException)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to edit/delete student record. Please try again.", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
