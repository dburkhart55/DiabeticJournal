using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;

namespace DiabeticJournal.ViewModels.Ratio
{
    [QueryProperty(nameof(Ratio), "ratio")]
    [QueryProperty(nameof(Id), "id")]
    public partial class ViewRatioPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        int id;

        [ObservableProperty]
        TempRatio ratio;


        readonly Database db;
        public ViewRatioPageViewModel(Database database)
        {
            db = database;
            Title = "View Ratio";
            Console.WriteLine(Id.ToString());
            
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
        


        
        

        
    }
}
