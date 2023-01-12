using DiabeticJournal.ViewModels.Dashboard;

namespace DiabeticJournal.Views.Dashboard;

public partial class BloodCheckPage : ContentPage
{
	public BloodCheckPage(BloodCheckPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}