using Microsoft.Extensions.Logging;
using StudentsManagement.Services;
using StudentsManagement.ViewModels;
using StudentsManagement.Views;

namespace StudentsManagement;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Services
		builder.Services.AddSingleton<IStudentService, StudentService>();

		//Views Registration
		builder.Services.AddSingleton<StudentListView>();
		builder.Services.AddTransient<AddUpdateStudentView>();

		// ViewModels Registration
		builder.Services.AddSingleton<StudentListViewModel>();
		builder.Services.AddTransient<AddUpdateStudentViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
