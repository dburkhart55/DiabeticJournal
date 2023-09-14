using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.Views.CorrectionFactor;
using System.Collections.ObjectModel;

namespace DiabeticJournal.ViewModels.CorrectionFactor
{
    public partial class UserCFPageViewModel : BaseViewModel
    {
        
        public ObservableCollection<HBSCF> CFs { get; set; } = new ObservableCollection<HBSCF>();

        Database db;

        public UserCFPageViewModel(Database database) 
        {
            db = database;
            Title = "User Correction Factors";

        }




        [ICommand]
        public async void GetCFList()
        {
            CFs.Clear();
            var cfList = await db.GetCFAsync();
            string userId = await SecureStorage.Default.GetAsync("Logged_UserId");
            int UserId = Int32.Parse(userId);
            if (cfList.Count > 0)
            {
                
                cfList = cfList.OrderBy(f => f.StartTime).ToList();
                foreach(var cf in cfList)
                {
                    if(cf.UserId == UserId)
                    {
                        CFs.Add(cf);

                    }
                }
            }
        }

        [ICommand]
        public async void AddCF()
        {
            await Shell.Current.GoToAsync(nameof(AddCFPage),false);
        }

        [ICommand]
        public async void DisplayAction(HBSCF cf)
        {
            var response = await AppShell.Current.DisplayActionSheet("Selelct an Option " + cf.Id, null, null, "Edit", "Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("cf", cf);
                await Shell.Current.DisplayAlert("debug", navParam.ToString(), "OK");
                await AppShell.Current.GoToAsync(nameof(ViewCFPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await db.DeleteCF(cf);
                if(delResponse > 0)
                {
                    //await AppShell.Current.GoToAsync(nameof(UserRatioPage));
                    //BuildList();
                    GetCFList();
                }
            }
        }
    }
}
