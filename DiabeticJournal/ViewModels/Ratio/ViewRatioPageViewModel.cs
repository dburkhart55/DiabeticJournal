using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using CommunityToolkit.Mvvm.Input;

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
            
            Task.Run(() => setTimes());
            //SelectRatio();

            


            /*CarbRate = R1.CarbRate;
            Start = TimeOnly.Parse(R1.StartTime);
            End = TimeOnly.Parse(R1.EndTime);*/
        }

        /*async void SelectRatio()
        {
            Ratio = await db.GetRatio(Id);

            Console.WriteLine(Ratio.Id.ToString());
        }*/

        public void setTimes()
        {
            Test = "This has been triggered";
            StartTime = TimeSpan.Parse(Ratio.StartTime);
            EndTime = TimeSpan.Parse(Ratio.EndTime);
        }

        [ICommand]
        public async void UpdateRatio()
        {
            int response = -1;
            if(Ratio.Id > 0)
            {
                response = 1;
            }
        }


        
        

        
    }
}
