using DiabeticJournal.ViewModels.User;

namespace DiabeticJournal.Views.User;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}