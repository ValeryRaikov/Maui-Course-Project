using StudentsManagement.ViewModels;

namespace StudentsManagement.Views;

public partial class StudentListView : ContentPage
{
	public StudentListView(StudentListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}