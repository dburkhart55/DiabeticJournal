using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.Views.CorrectionFactor;

namespace DiabeticJournal.ViewModels.CorrectionFactor
{

    public partial class AddCFPageViewModel : BaseViewModel
    {
        Database db;

        [ObservableProperty]
        private int _cf;

        [ObservableProperty]
        private TimeSpan _start;

        [ObservableProperty]
        private TimeSpan _end;

        public AddCFPageViewModel(Database database)
        {
            db = database;
            Title = "Add Correction Factor";
            
        }

        [ICommand]
        async void CFSubmit()
        {
            var sst = Start.ToString();
            var set = End.ToString();

            TimeOnly st = TimeOnly.Parse(sst);
            TimeOnly et = TimeOnly.Parse(set);

            string userId = await SecureStorage.Default.GetAsync("Logged_UserId");

            int UserId = Int32.Parse(userId);




            HBSCF cf = new HBSCF();
            cf.UserId = UserId;
            cf.CorrectionFactor = Cf;
            cf.StartTime = st.ToString();
            cf.EndTime = et.ToString();

            int result = await db.AddCF(cf);

            if(result == 1)
            {
                Start = TimeSpan.Parse("00:00:00");
                End = TimeSpan.Parse("00:00:00");
                Cf = 0;

                await Shell.Current.DisplayAlert("Correction Factor Submission", "Your new correction factor has been added successfully", "ok");
                await AppShell.Current.GoToAsync($"//{nameof(UserCFPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "There was an error with your submission. Please try again.", "ok");

            }

        }
    }
}
