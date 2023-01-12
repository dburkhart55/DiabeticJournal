using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Startup;

namespace DiabeticJournal.Views.Startup;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}


    
}