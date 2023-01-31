using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Ratio;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;



namespace DiabeticJournal.Views.Ratio;

public partial class UserRatioPage : ContentPage
{
    UserRatioPageViewModel _viewModel;
	public UserRatioPage(UserRatioPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
        _viewModel = viewModel;
        
        
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetRatioList();
    }

    private async void RatioTapped(object sender, ItemTappedEventArgs e)
    {
        var ratio = (Models.Ratio)e.Item;

        await Shell.Current.GoToAsync(nameof(ViewRatioPage), false, new Dictionary<string, object>
        {
            {

                "ratio", ratio
            }

        });
        

    }

    


}