
using DiabeticJournal.ViewModels.Ratio;

namespace DiabeticJournal.Views.Ratio;

public partial class ViewRatioPage : ContentPage
{
	ViewRatioPageViewModel _viewModel;
	public ViewRatioPage(ViewRatioPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext= viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.StartTime = DateTime.Parse(_viewModel.Ratio.StartTime).TimeOfDay;
		_viewModel.EndTime = DateTime.Parse(_viewModel.Ratio.EndTime).TimeOfDay;
    }
}