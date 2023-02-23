using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.Ratio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Ratio
{

    public partial class AddRatioPageViewModel : BaseViewModel
    {
        Database db;

        [ObservableProperty]
        private double _carb;

        [ObservableProperty]
        private TimeSpan _start;

        [ObservableProperty]
        private TimeSpan _end;

        public AddRatioPageViewModel(Database database)
        {
            db = database;
            Title = "Add Carb Ratio";
            
        }

        [ICommand]
        async void RatioSubmit()
        {
            var sst = Start.ToString();
            var set = End.ToString();

            TimeOnly st = TimeOnly.Parse(sst);
            TimeOnly et = TimeOnly.Parse(set);
            

            

            Models.Ratio ratio = new Models.Ratio();
            ratio.CarbRate = Carb;
            ratio.StartTime = st.ToString();
            ratio.EndTime = et.ToString();

            int result = await db.AddRatio(ratio);

            if(result == 1)
            {
                Start = TimeSpan.Parse("00:00:00");
                End = TimeSpan.Parse("00:00:00");
                Carb = 0;

                await Shell.Current.DisplayAlert("Ratio Submission", "Your new ratio has been added successfully", "ok");
                await AppShell.Current.GoToAsync($"//{nameof(UserRatioPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "There was an error with your submission. Please try again.", "ok");

            }

        }
    }
}
