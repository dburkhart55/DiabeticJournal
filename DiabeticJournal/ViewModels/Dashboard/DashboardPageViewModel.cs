
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Views.Dashboard;
using DiabeticJournal.Views.Ratio;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Dashboard
{
    public partial class DashboardPageViewModel : BaseViewModel
    {
        public DashboardPageViewModel()
        {
            Title = "Welcome, " + App.loggedInUser.FirstName.ToUpper() + "!";
            

        }

        [ICommand]
        async void BloodCheckNav()
        {
            await Shell.Current.GoToAsync($"//{nameof(BloodCheckPage)}");
        }

        [ICommand]
        async void UserRatioNav()
        {
            await Shell.Current.GoToAsync($"//{nameof(UserRatioPage)}");
        }
        
    }
}
