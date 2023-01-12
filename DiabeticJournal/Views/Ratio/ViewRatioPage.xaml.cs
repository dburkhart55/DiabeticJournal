using DiabeticJournal.ViewModels.Ratio;

namespace DiabeticJournal.Views.Ratio;

public partial class ViewRatioPage : ContentPage
{
	public ViewRatioPage(ViewRatioPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext= viewModel;
	}
}