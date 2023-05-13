using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Startup;
using DiabeticJournal.Views.Startup;
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
        public double basalFactor;

        [ObservableProperty]
        public List<Units> unitList;

        [ObservableProperty]
        public Units unit;

        [ObservableProperty]
        public List<BasalFactor> factorList;

        [ObservableProperty]
        public BasalFactor factor;


        public RegistrationPageViewModel(Database database)
        {
            db = database;
            Title = "User Registration";
            BuildPicker();
            basalFactorList();
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
            foreach(var unit in UnitList)
            {
                await Shell.Current.DisplayAlert("title", unit.Id.ToString() + ' ' + unit.Name, "OK");

            }
            return;
        }

        public async void basalFactorList()
        {
            List<BasalFactor> list = new List<BasalFactor>();
            list = await db.GetFactors();
            if (list.Count > 0)
            {
                FactorList = list;
            }
            foreach (var fact in FactorList)
            {
                await Shell.Current.DisplayAlert("title", fact.Id.ToString() + ' ' + fact.FactorRate.ToString(), "OK");

            }
            return;
        }

        [ICommand]
        async void SubmitUser()
        {
            var encryptPass = LoginPageViewModel.EncryptPass(Password);


            Models.User user = new Models.User();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserName = UserName;
            user.Email = Email;
            user.Password = encryptPass;
            user.Weight = Weight;
            user.TargetSugar = TargetSugar;
            user.SAInsulin = SAInsulin;
            user.FAInsulin = FAInsulin;
            user.DoctorEmail = DoctorEmail;
            user.DoctorName = DoctorName;
            user.BasalFactor = Factor.Id;
            user.OverNightBasal = OverNightBasalRate;
            user.Units = Unit.Id;

            var result = await db.SaveUserAsync(user);


            if (result == 1)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", false);
            }
            else
            {
                await Shell.Current.DisplayAlert("Submission Error", "There was error in submitting your profile. Please verify your information and submit again.", "ok");
            }
        }


    }
}
