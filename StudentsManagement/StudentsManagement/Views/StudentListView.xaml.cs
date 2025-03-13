using StudentsManagement.ViewModels;

namespace StudentsManagement.Views;

public partial class StudentListView : ContentPage
{
	private StudentListViewModel _viewModel;

	public StudentListView(StudentListViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;

		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(null);
    }
}