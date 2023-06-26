using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;

namespace DiabeticJournal.ViewModels.User
{
    public partial class UserSettingsPageViewModel : BaseViewModel
    {
        public Database db;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public double weight;

        [ObservableProperty]
        public int targetSugar;

        [ObservableProperty]
        public string fAInsulin;

        [ObservableProperty]
        public string sAInsulin;

        [ObservableProperty]
        public double overNightBasalRate;

        [ObservableProperty]
        public string doctorName;

        [ObservableProperty]
        public string doctorEmail;

        [ObservableProperty]
        public int basalFactor;

        [ObservableProperty]
        public List<Units> unitList;

        [ObservableProperty]
        public Units unit;

        [ObservableProperty]
        public List<BasalFactor> factorList;

        [ObservableProperty]
        public BasalFactor factor;


        public UserSettingsPageViewModel(Database database)
        {
            db = database;
            Title = "User Settings";
            UserSet();
            BuildPicker();
            basalFactorList();
            //Shell.Current.DisplayAlert("TItle", UnitList.ToString(), "OK");
        }

        async void UserSet()
        {

            string userId = await SecureStorage.Default.GetAsync("Logged_UserId");

            Int32.TryParse(userId, out int Id);

            List<Models.User> userList = await db.GetUsers();

            foreach(Models.User user in userList)
            {
                if(Id == user.Id)
                {
                    
                    FirstName = user.FirstName;
                    LastName = user.LastName;
                    UserName = user.UserName;
                    Email = user.Email;
                    Weight = (double)user.Weight;
                    TargetSugar = (int)user.TargetSugar;
                    Unit = await db.UnitsSearch(user.Units);
                    FAInsulin = user.FAInsulin;
                    SAInsulin = user.SAInsulin;
                    OverNightBasalRate = (double)user.OverNightBasal;
                    DoctorName = user.DoctorName;
                    DoctorEmail = user.DoctorEmail;
                    Factor = await db.BasalFactorSearch((int)user.BasalFactor);
                    UserName = user.UserName;
                    

                    
                }
            }

        }

        async void BuildPicker()
        {
            List<Units> list = new List<Units>();
            list = await db.GetUnits();
            if (list.Count > 0)
            {
                UnitList = list;
            }
            /*foreach (var unit in UnitList)
            {
                await Shell.Current.DisplayAlert("title", unit.Id.ToString() + ' ' + unit.Name, "OK");

            }*/
            return;
        }

        async void basalFactorList()
        {
            List<BasalFactor> list = new List<BasalFactor>();
            list = await db.GetFactors();
            if (list.Count > 0)
            {
                FactorList = list;
            }
            /*foreach (var fact in FactorList)
            {
                await Shell.Current.DisplayAlert("title", fact.Id.ToString() + ' ' + fact.FactorRate.ToString(), "OK");

            }*/
            return;
        }
    }
}
