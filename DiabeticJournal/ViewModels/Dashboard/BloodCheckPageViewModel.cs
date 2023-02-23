using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Dashboard
{
    public partial class BloodCheckPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<Test> _test;

        [ObservableProperty]
        private int? _bloodSugar = null;

        [ObservableProperty]
        private DateTime _date = DateTime.Now;

        [ObservableProperty]
        private TimeSpan _time;


        [ObservableProperty]
        private Test _selectedType;

        [ObservableProperty]
        private int? _carbs = null;

        [ObservableProperty]
        private string? _comment = null;

        Database db;




        public BloodCheckPageViewModel(Database database)
        {
            db = database;
            Title = "Add New Blood Sugar Reading";
            BuildPicker();
           
        }

        public async void BuildPicker()
        {
            List<Test> list = new List<Test>();
            list = await db.GetAllTypeAsync();
            if(list.Count > 0)
            {
                Test = list;
            }
            return;
        }

        [ICommand]
        async void Calculate()
        {
           

            App.Current.MainPage.DisplayAlert("testing", BloodSugar.ToString() + " " + Date.ToString() + " " + Time.ToString() + " " + SelectedType.Name + " " + Carbs.ToString() + " " + Comment, "OK");

            Models.Ratio ratio = await db.GetRatioByTime(Time);

            App.Current.MainPage.DisplayAlert("testing", ratio.StartTime + " " + ratio.CarbRate + " " + ratio.EndTime, "OK");
            
            /* switch(SelectedType.Name) 
            {
                case "Bolus":
                    Ratio ratio = await db.
                    int insulin = Carbs/
                    break;
                case "High Blood Sugar Correction":
                    break;
                case "Standard Check":
                    break;
            }*/

        }
    }
}
