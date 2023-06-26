using DiabeticJournal.ViewModels.User;

namespace DiabeticJournal.Views.User;

public partial class UserSettingPage : ContentPage
{
	public UserSettingPage(UserSettingsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}



}