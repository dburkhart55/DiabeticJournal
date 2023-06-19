using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.Ratio;
using DiabeticJournal.Models;

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
        TimeSpan startTime;

        [ObservableProperty]
        TimeSpan endTime;




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
                var sst = StartTime.ToString();
                var set = EndTime.ToString();

                TimeOnly st = TimeOnly.Parse(sst);
                TimeOnly et = TimeOnly.Parse(set);
                Ratio.StartTime = st.ToString();
                Ratio.EndTime = et.ToString();


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
