using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Ratio;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace DiabeticJournal.Views.Ratio;

public partial class UserRatioPage : ContentPage
{
	public UserRatioPage(UserRatioPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
        
    }

   


    private async void RatioTapped(object sender, ItemTappedEventArgs e)
    {
        var ratio = (Models.Ratio)e.Item;
        /*DateTime dateTime = DateTime.ParseExact(ratio.StartTime, "hh:mm tt", CultureInfo.InvariantCulture);
        TimeSpan span = dateTime.TimeOfDay;

        DateTime dateTime2 = DateTime.ParseExact(ratio.EndTime, "hh:mm tt", CultureInfo.InvariantCulture);
        TimeSpan span2 = dateTime2.TimeOfDay;

        TempRatio r1 = new TempRatio();
        r1.Id = ratio.Id;
        r1.CarbRate= ratio.CarbRate;
        r1.StartTime = span;
        r1.EndTime = span2;*/
        int id = ratio.Id;


        if (ratio == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(ViewRatioPage)}?Id={id}");

        /*await Shell.Current.GoToAsync(nameof(ViewRatioPage), false, new Dictionary<string, object>
        {
            {

                "ratio", r1
            }

        });*/
        

    }
}