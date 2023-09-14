using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.CorrectionFactor;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;



namespace DiabeticJournal.Views.CorrectionFactor;

public partial class UserCFPage : ContentPage
{
    UserCFPageViewModel _viewModel;
	public UserCFPage(UserCFPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
        _viewModel = viewModel;
        
        
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetCFList();
    }

    private async void CFTapped(object sender, ItemTappedEventArgs e)
    {
        var cf = (HBSCF)e.Item;

        await Shell.Current.GoToAsync(nameof(ViewCFPage), false, new Dictionary<string, object>
        {
            {

                "cf", cf
            }

        });
        

    }

    


}