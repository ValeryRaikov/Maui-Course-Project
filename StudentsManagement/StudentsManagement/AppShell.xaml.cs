using StudentsManagement.Views;

namespace StudentsManagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddUpdateStudentView), typeof(AddUpdateStudentView));
        }
    }
}
