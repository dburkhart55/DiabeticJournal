using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Ratio
{
    public partial class UserRatioPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<Models.Ratio> _ratioList;

        Database db;

        public UserRatioPageViewModel(Database database) 
        {
            db = database;
            Title = "User Ratios";
            BuildList();
        }


        public async void BuildList()
        {
            List<Models.Ratio> list = new List<Models.Ratio>();
            list = await db.GetRatiosAsync();
            if (list.Count > 0)
            {
                RatioList = list;
            }
            return;
        }

        /*[ICommand]
        async void ViewRatioPage(Models.Ratio ratio)
        {
            await Shell.Current.GoToAsync($"//{nameof(ViewRatioPage(ratio))}");
        }*/
    }
}
