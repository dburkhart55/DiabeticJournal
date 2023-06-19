using DiabeticJournal.Models;
using DiabeticJournal.ViewModels;
using DiabeticJournal.ViewModels.Startup;
using DiabeticJournal.Views.Dashboard;
using DiabeticJournal.Views.Ratio;
using DiabeticJournal.Views.User;
using DiabeticJournal.Views.CorrectionFactor;
using DiabeticJournal.Views.BloodLog;
using DiabeticJournal.ViewModels.User;

namespace DiabeticJournal;

public partial class AppShell : Shell
{


	Database db;
   

    public AppShell(Database database)
	{
		InitializeComponent();
		db = database;
		db.Init();
		
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
		Routing.RegisterRoute(nameof(BloodCheckPage), typeof(BloodCheckPage));
		Routing.RegisterRoute(nameof(UserRatioPage), typeof(UserRatioPage));
		Routing.RegisterRoute(nameof(ViewRatioPage), typeof(ViewRatioPage));
		Routing.RegisterRoute(nameof(AddRatioPage), typeof(AddRatioPage));
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
		Routing.RegisterRoute(nameof(UserCFPage), typeof(UserCFPage));
		Routing.RegisterRoute(nameof(AddCFPage), typeof(AddCFPage));
        Routing.RegisterRoute(nameof(ViewCFPage), typeof(ViewCFPage));
        Routing.RegisterRoute(nameof(BloodLogPage), typeof(BloodLogPage));

	}


    
}
