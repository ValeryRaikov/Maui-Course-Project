using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Data;
using StudentsManagement.Exceptions;
using StudentsManagement.Services;

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
            try
            {
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
    }
}
