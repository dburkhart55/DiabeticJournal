using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.BloodLog;

namespace DiabeticJournal.ViewModels.BloodLog
{
    [QueryProperty(nameof(rec), "rec")]
    public partial class ViewBloodRecPageViewModel : BaseViewModel
    {
        
            [ObservableProperty]
            BloodRec rec = new Models.BloodRec();

            [ObservableProperty]

           

            [ObservableProperty]
            

            [ObservableProperty]
           




            readonly Database db;
            public ViewBloodRecPageViewModel(Database database)
            {
                db = database;
                Title = "View Blood Sugar Record";



            }
        }
}
