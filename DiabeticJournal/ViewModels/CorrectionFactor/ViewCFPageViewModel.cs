using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.CorrectionFactor;

namespace DiabeticJournal.ViewModels.CorrectionFactor
{
    [QueryProperty(nameof(cf), "cf")]
    //[QueryProperty(nameof(Id), "id")]
    public partial class ViewCFPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string test;

        [ObservableProperty]
        HBSCF cf = new Models.HBSCF();

        [ObservableProperty]
        TimeSpan startTime = new TimeSpan();

        [ObservableProperty]
        TimeSpan endTime = new TimeSpan();




        readonly Database db;
        public ViewCFPageViewModel(Database database)
        {
            db = database;
            Title = "View Correction Factor";
            
            
            
        }

        [ICommand]
        public async void UpdateCF()
        {
            int response = -1;
            if(Cf.Id > 0)
            {
                response = await db.UpdateCF(Cf);

                if (response == 1)
                {
                    await AppShell.Current.GoToAsync($"//{nameof(UserCFPage)}");
                }
            }
            else
            {

            }
        }


        
        

        
    }
}
