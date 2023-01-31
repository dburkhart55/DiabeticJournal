using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.Ratio;

namespace DiabeticJournal.ViewModels.Ratio
{
    [QueryProperty(nameof(Ratio), "ratio")]
    //[QueryProperty(nameof(Id), "id")]
    public partial class ViewRatioPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string test;

        [ObservableProperty]
        Models.Ratio ratio = new Models.Ratio();

        [ObservableProperty]
        TimeSpan startTime = new TimeSpan();

        [ObservableProperty]
        TimeSpan endTime = new TimeSpan();




        readonly Database db;
        public ViewRatioPageViewModel(Database database)
        {
            db = database;
            Title = "View Ratio";
            
            
            
        }

        [ICommand]
        public async void UpdateRatio()
        {
            int response = -1;
            if(Ratio.Id > 0)
            {
                response = await db.UpdateRatio(Ratio);

                if (response == 1)
                {
                    await AppShell.Current.GoToAsync($"//{nameof(UserRatioPage)}");
                }
            }
            else
            {

            }
        }


        
        

        
    }
}
