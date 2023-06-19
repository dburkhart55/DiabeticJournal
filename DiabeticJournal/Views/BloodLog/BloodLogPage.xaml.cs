
using DiabeticJournal.ViewModels.BloodLog;
using DiabeticJournal.ViewModels.CorrectionFactor;

namespace DiabeticJournal.Views.BloodLog;

public partial class BloodLogPage : ContentPage
{
    BloodLogPageViewModel _viewModel;
    public BloodLogPage(BloodLogPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
        _viewModel = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetRecList();
    }
}