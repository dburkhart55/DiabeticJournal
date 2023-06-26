using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.BloodLog
{
    public partial class BloodLogPageViewModel : BaseViewModel
    {
        Database db;
        public ObservableCollection<BloodRec> Recs { get; set; } = new ObservableCollection<BloodRec>();



        public BloodLogPageViewModel(Database database)
        {
            db = database;
            Title = "Blood Log";


        }

        [ICommand]
        public async void GetRecList()
        {
            Recs.Clear();
            var recList = await db.GetBloodRecsAsync();
            string userId = await SecureStorage.Default.GetAsync("Logged_UserId");
            int UserId = Int32.Parse(userId);
            if (recList.Count > 0)
            {

                recList = recList.OrderBy(f => f.Date).ToList();
                foreach (var rec in recList)
                {
                    if (rec.UserId == UserId)
                    {
                       if(rec.Insulin == 0)
                        {
                            rec.Insulin = 0;
                        }
                        
                        Recs.Add(rec);

                    }
                }
            }
        }
    }
}
