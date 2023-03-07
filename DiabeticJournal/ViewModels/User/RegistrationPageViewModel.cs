using CommunityToolkit.Mvvm.ComponentModel;
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
        public int basalFactor;

        [ObservableProperty]
        public List<Models.Units> unitList;

        [ObservableProperty]
        public int unitID;


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


    }
}
