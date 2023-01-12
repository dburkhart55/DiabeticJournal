using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiabeticJournal.Models;
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
        private string _username;

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
                await App.Current.MainPage.DisplayAlert("Invalid Username or Password", "Please enter a username and password.", "OK");
            }
            else
            {
                User user = new User();
                user.UserName = Username; 
                user.Password = EncryptPass(Password);

                User loggedIn = await ValidateCreds(user);

                if(loggedIn != null)
                {
                    App.loggedInUser = loggedIn;
                    await Shell.Current.GoToAsync($"//{nameof(Dashboard)}");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid Username or Password", "Please enter a valid username and password.", "OK");
                }
            }
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


        public async Task<User> ValidateCreds(User login)
        {
            
            List<User> userList = await db.GetUsers();

            if(userList.Count > 0)
            {
                foreach(User u in userList)
                {
                    if(u.UserName.ToUpper() == login.UserName.ToUpper() && u.Password == login.Password)
                    {
                        User user = new User();
                        user.UserName = u.UserName;
                        user.Password = u.Password;
                        user.Email = u.Email;
                        user.FirstName = u.FirstName;
                        user.LastName = u.LastName;
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

    }
}
