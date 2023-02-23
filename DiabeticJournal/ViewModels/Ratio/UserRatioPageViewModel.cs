using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.Views.Ratio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Ratio
{
    public partial class UserRatioPageViewModel : BaseViewModel
    {
        
        public ObservableCollection<Models.Ratio> Ratios { get; set; } = new ObservableCollection<Models.Ratio>();

        Database db;

        public UserRatioPageViewModel(Database database) 
        {
            db = database;
            Title = "User Ratios";

        }




        [ICommand]
        public async void GetRatioList()
        {
            Ratios.Clear();
            var ratioList = await db.GetRatiosAsync();
            if(ratioList?.Count > 0)
            {
                ratioList = ratioList.OrderBy(f => f.StartTime).ToList();
                foreach(var ratio in ratioList)
                {
                    Ratios.Add(ratio);
                }
            }
        }

        [ICommand]
        public async void AddRatio()
        {
            await Shell.Current.GoToAsync(nameof(AddRatioPage),false);
        }

        [ICommand]
        public async void DisplayAction(Models.Ratio ratio)
        {
            var response = await AppShell.Current.DisplayActionSheet("Selelct an Option", "OK", null, "Edit", "Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ratio", ratio);
                await AppShell.Current.GoToAsync(nameof(ViewRatioPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await db.DeleteRatio(ratio);
                if(delResponse > 0)
                {
                    //await AppShell.Current.GoToAsync(nameof(UserRatioPage));
                    //BuildList();
                    GetRatioList();
                }
            }
        }
    }
}
