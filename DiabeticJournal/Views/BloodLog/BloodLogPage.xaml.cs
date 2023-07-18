using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.BloodLog;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

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

    private async void RecTapped(object sender, ItemTappedEventArgs e)
    {
        var rec = (BloodRec)e.Item;

        await Shell.Current.GoToAsync(nameof(ViewBloodRecPage), false, new Dictionary<string, object>
        {
            {

                "rec", rec
            }

        });


    }
}