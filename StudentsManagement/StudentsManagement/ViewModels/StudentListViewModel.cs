using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentsManagement.Data;
using StudentsManagement.Exceptions;
using StudentsManagement.Services;
using StudentsManagement.Views;
using System.Collections.ObjectModel;

namespace StudentsManagement.ViewModels
{
    public partial class StudentListViewModel : ObservableObject
    {
        public ObservableCollection<StudentEntity> Students { get; set; } = new ObservableCollection<StudentEntity>();

        private readonly IStudentService _studentService;

        public StudentListViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async Task GetStudentList()
        {
            try
            {
                var studentList = await _studentService.GetStudentList();

                if (studentList?.Any() == true)
                {
                    Students.Clear();
                    foreach (var student in studentList)
                    {
                        Students.Add(student);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Info", "No student records found. Add new students.", "OK");
                }
            }
            catch (DatabaseException)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to load student list. Please try again.", "OK");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Unexpected error occured. Please try again.", "OK");
            }
        }

        [RelayCommand]
        public async Task AddUpdateStudent()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AddUpdateStudentView));
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Unexpected error occured. Please try again.", "OK");
            }
        }

        [RelayCommand]
        public async Task DisplayAction(StudentEntity studentEntity)
        {
            try
            {
                var response = await Shell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

                if (response == "Edit")
                {
                    var navParam = new Dictionary<string, object>();
                    navParam?.Add("StudentDetail", studentEntity);

                    await Shell.Current.GoToAsync(nameof(AddUpdateStudentView), navParam);
                }
                else if (response == "Delete")
                {
                    bool confirm = await Shell.Current.DisplayAlert("Confirm",
                        "Are you sure you want to delete this student?", "Yes", "No");

                    if (confirm)
                    {
                        var delResponse = await _studentService.DeleteStudent(studentEntity);

                        if (delResponse > 0)
                        {
                            Students.Remove(studentEntity);

                            if (Students.Count == 0)
                            {
                                Students.Clear();
                                await Shell.Current.DisplayAlert("Info", "No student records found.", "OK");
                            }
                        }
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
