using DiabeticJournal.ViewModels.Dashboard;
using DiabeticJournal.ViewModels.Ratio;
using DiabeticJournal.ViewModels.Startup;
using DiabeticJournal.Views.Dashboard;
using DiabeticJournal.Views.Ratio;
using DiabeticJournal.Views.Startup;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DiabeticJournal;

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

        
        //builder.Services.AddSingleton<DBRepository>(s => ActivatorUtilities.CreateInstance<DBRepository>(s, Constants.DatabasePath));

       

        //views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<BloodCheckPage>();
        builder.Services.AddSingleton<UserRatioPage>();
        builder.Services.AddSingleton<ViewRatioPage>();

        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<DashboardPageViewModel>();
        builder.Services.AddSingleton<BloodCheckPageViewModel>();
        builder.Services.AddSingleton<UserRatioPageViewModel>();
        builder.Services.AddSingleton<ViewRatioPageViewModel>();

        builder.Services.AddSingleton<Database>();



        return builder.Build();
	}
}
