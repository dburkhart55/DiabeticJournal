using DiabeticJournal.ViewModels.Dashboard;
using DiabeticJournal.ViewModels.Ratio;
using DiabeticJournal.ViewModels.Startup;
using DiabeticJournal.ViewModels.User;
using DiabeticJournal.ViewModels.CorrectionFactor;
using DiabeticJournal.Views.Dashboard;
using DiabeticJournal.Views.Ratio;
using DiabeticJournal.Views.Startup;
using DiabeticJournal.Views.User;
using DiabeticJournal.Views.CorrectionFactor;
using DiabeticJournal.Views.BloodLog;
using DiabeticJournal.ViewModels.BloodLog;
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
        builder.Services.AddSingleton<AddRatioPage>();
        builder.Services.AddSingleton<RegistrationPage>();
        builder.Services.AddSingleton<UserCFPage>();
        builder.Services.AddSingleton<ViewCFPage>();
        builder.Services.AddSingleton<AddCFPage>();
        builder.Services.AddSingleton<BloodLogPage>();
        builder.Services.AddSingleton<UserSettingPage>();
        builder.Services.AddSingleton<ViewBloodRecPage>();



        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<DashboardPageViewModel>();
        builder.Services.AddSingleton<BloodCheckPageViewModel>();
        builder.Services.AddSingleton<UserRatioPageViewModel>();
        builder.Services.AddSingleton<ViewRatioPageViewModel>();
        builder.Services.AddSingleton<AddRatioPageViewModel>();
        builder.Services.AddSingleton<RegistrationPageViewModel>();
        builder.Services.AddSingleton<UserCFPageViewModel>();
        builder.Services.AddSingleton<AddCFPageViewModel>();
        builder.Services.AddSingleton<ViewCFPageViewModel>();
        builder.Services.AddSingleton<BloodLogPageViewModel>();
        builder.Services.AddSingleton<UserSettingsPageViewModel>();
        builder.Services.AddSingleton<ViewBloodRecPageViewModel>();

        builder.Services.AddSingleton<Database>();



        return builder.Build();
	}
}
