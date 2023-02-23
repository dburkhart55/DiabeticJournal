using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.User
{
    public partial class RegistrationPageViewModel : BaseViewModel
    {
        Database db;

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

    }
}
