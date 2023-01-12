﻿using DiabeticJournal.Models;
using DiabeticJournal.ViewModels;
using DiabeticJournal.ViewModels.Startup;
using DiabeticJournal.Views.Dashboard;
using DiabeticJournal.Views.Ratio;

namespace DiabeticJournal;

public partial class AppShell : Shell
{

   

   

    public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
		Routing.RegisterRoute(nameof(BloodCheckPage), typeof(BloodCheckPage));
		Routing.RegisterRoute(nameof(UserRatioPage), typeof(UserRatioPage));
		Routing.RegisterRoute(nameof(ViewRatioPage), typeof(ViewRatioPage));
	}


    
}