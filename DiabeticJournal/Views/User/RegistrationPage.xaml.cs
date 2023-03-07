using DiabeticJournal.ViewModels.User;

using DiabeticJournal.Models;

namespace DiabeticJournal.Views.User;

public partial class RegistrationPage : ContentPage
{
    
	public RegistrationPage(RegistrationPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
        
		


	}


    

}