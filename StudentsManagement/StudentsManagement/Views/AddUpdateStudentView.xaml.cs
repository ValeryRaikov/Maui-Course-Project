using StudentsManagement.ViewModels;

namespace StudentsManagement.Views;

public partial class AddUpdateStudentView : ContentPage
{
	public AddUpdateStudentView(AddUpdateStudentViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}