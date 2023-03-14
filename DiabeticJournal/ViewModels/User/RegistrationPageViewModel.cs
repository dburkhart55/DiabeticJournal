using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.User
{
    public partial class RegistrationPageViewModel : BaseViewModel
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
        public int unitId;

        [ObservableProperty]
        public string fAInsulin;

        [ObservableProperty]
        public string sAInsulin;

        [ObservableProperty]
        public string overNightBasalRate;

        [ObservableProperty]
        public string doctorName;

        [ObservableProperty]
        public string doctorEmail;

        [ObservableProperty]
        public double basalFactor;

        [ObservableProperty]
        public List<Units> unitList;

        [ObservableProperty]
        public int unitID;

        [ObservableProperty]
        public List<BasalFactor> factorList;


        public RegistrationPageViewModel(Database database)
        {
            db = database;
            Title = "User Registration";
            BuildPicker();
            //Shell.Current.DisplayAlert("TItle", UnitList.ToString(), "OK");
        }

        public async void BuildPicker()
        {
            List<Units> list = new List<Units>();
            list = await db.GetUnits();
            if (list.Count > 0)
            {
                UnitList = list;
            }
            return;
        }

        [ICommand]
        async void SubmitUser()
        {
            Models.User user = new Models.User();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserName = UserName;
            user.Email = Email;
            user.Password = Password;
            user.Weight = Weight;
            user.TargetSugar = TargetSugar;
            user.SAInsulin = SAInsulin;
            user.FAInsulin = FAInsulin;
        }


    }
}
