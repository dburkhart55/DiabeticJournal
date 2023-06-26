using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.Views.CorrectionFactor;
using DiabeticJournal.Views.Dashboard;
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
        public List<Test> _test;

        [ObservableProperty]
        public int _bloodSugar;

        [ObservableProperty]
        public DateTime _date = DateTime.Now;

        [ObservableProperty]
        public TimeSpan _time;


        [ObservableProperty]
        public Test _selectedType;

        [ObservableProperty]
        public int? _carbs = null;

        [ObservableProperty]
        public string? _comment = null;

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

            var userId = await SecureStorage.Default.GetAsync("Logged_UserId");

            int UserId = Int32.Parse(userId);



            switch (SelectedType.Name) 
            {
                case "Bolus":
                    Models.Ratio ratio = await db.GetRatioByTime(Time);
                    var carbRate = ratio.CarbRate;
                    int insulin = (int)Carbs/carbRate;
                    await Shell.Current.DisplayAlert("Meal Bolus","Your meal time bolus is: " + insulin.ToString(), "ok");

                    var sst = Time.ToString();
                    TimeOnly time = TimeOnly.Parse(sst);

                    BloodRec rec = new BloodRec();
                    rec.Carbs = carbRate;
                    rec.UserId = UserId;
                    rec.Date = DateTime.Now;
                    rec.Time = time.ToString();
                    rec.Sugar = BloodSugar;
                    rec.TestId = SelectedType.Id;
                    rec.Insulin = insulin;
                    rec.Comment = Comment;
                    var result = await db.AddBloodRec(rec);

                    if(result == 1)
                    {
                        ClearForm();
                        await AppShell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                    }
                    break;
                case "High Blood Sugar Correction":
                   
                    
                    HBSCF cf = await db.GetCFByTime(Time);
                    Models.User user = await db.GetUser(UserId);
                    int target = (int)user.TargetSugar;
                    var rate = cf.CorrectionFactor;
                    int diff = BloodSugar - target;
                    int correction = diff/rate;
                    await Shell.Current.DisplayAlert("Correction","Your correction is: " + correction.ToString(), "ok");

                    var st = Time.ToString();
                    TimeOnly time1 = TimeOnly.Parse(st);

                    BloodRec rec1 = new BloodRec();
                    
                    rec1.UserId = UserId;
                    rec1.Date = DateTime.Now;
                    rec1.Time = time1.ToString();
                    rec1.Sugar = BloodSugar;
                    rec1.TestId = SelectedType.Id;
                    rec1.Insulin = correction;
                    rec1.Comment = Comment;
                    var result1 = await db.AddBloodRec(rec1);

                    if (result1 == 1)
                    {
                        ClearForm();
                        await AppShell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                    }
                    break;
                case "Standard Check":
                    await Shell.Current.DisplayAlert("Logged", "Your blood sugar has been logged.", "ok");

                    var t = Time.ToString();
                    TimeOnly time2 = TimeOnly.Parse(t);

                    BloodRec rec2 = new BloodRec();
                    
                    rec2.UserId = UserId;
                    rec2.Date = DateTime.Now;
                    rec2.Time = time2.ToString();
                    rec2.Sugar = BloodSugar;
                    rec2.TestId = SelectedType.Id;
                    
                    rec2.Comment = Comment;
                    var result2 = await db.AddBloodRec(rec2);

                    if (result2 == 1)
                    {
                        ClearForm();
                        await AppShell.Current.GoToAsync($"{nameof(DashboardPage)}");
                    }
                    break;
            }

        }


        async void ClearForm()
        {
            
            BloodSugar = 0;
            Time = TimeSpan.Parse("00:00");
            SelectedType = null;
            Carbs = 0;
            Comment = null;
        }
    }
}
