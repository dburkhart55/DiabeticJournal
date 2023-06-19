
using DiabeticJournal.ViewModels.CorrectionFactor;

namespace DiabeticJournal.Views.CorrectionFactor;

public partial class ViewCFPage : ContentPage
{
	ViewCFPageViewModel _viewModel;
	public ViewCFPage(ViewCFPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext= viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.StartTime = DateTime.Parse(_viewModel.Cf.StartTime).TimeOfDay;
		_viewModel.EndTime = DateTime.Parse(_viewModel.Cf.EndTime).TimeOfDay;
    }
}