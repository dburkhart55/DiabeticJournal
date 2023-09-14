using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
using DiabeticJournal.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DiabeticJournal.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _Username;

        [ObservableProperty]
        private string _password;

        Database db;

        public LoginPageViewModel(Database database)
        {
            db = database;

           
        }



        #region Commands
        [ICommand]
        async void Login()
        {
            if(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Models.Username or Password", "Please enter a Models.Username and password.", "OK");
            }
            else
            {
                Models.User user = new Models.User();
                user.UserName = Username; 
                user.Password = EncryptPass(Password);

                Models.User loggedIn = await ValidateCreds(user);

                if(loggedIn != null)
                {
                    App.loggedInUser = loggedIn;
                    ClearForm();
                    await Shell.Current.GoToAsync($"//{nameof(Dashboard)}");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid Username or Password", "Please enter a valid Username and password.", "OK");
                }
            }
        }

        [ICommand]
        async void RegisterNav()
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}",false);
        }
        #endregion


        public static string EncryptPass(string pass)
        {
            string salt = "nkw1hrT8@WH9Fro5";
            string pepper = "w07UMs4L$%R#4yN#";
            string input = salt + pass + pepper;

            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }



        public async Task<Models.User> ValidateCreds(Models.User login)
        {
            
            List<Models.User> UserList = await db.GetUsers();


            if(UserList.Count > 0)
            {
                foreach(var u in UserList)
                {
                   
                    
                    

                    if (u.UserName.ToUpper() == login.UserName.ToUpper())
                    {
                        if(u.Password == login.Password)
                        {
                            
                            await SecureStorage.Default.SetAsync("Logged_UserId", u.Id.ToString());
                            return u;
                        }
                        
                    }
                    
                }
            }

            return null;
        }

        async void ClearForm()
        {

            Username = null;
            Password = null;

            await App.Current.MainPage.DisplayAlert("test", "clear form called and completed", "OK");
        }

    }
}
