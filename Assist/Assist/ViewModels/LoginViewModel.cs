
using Assist.Services;
using Assist.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public AsyncCommand LoginCommand { get; set; }
        public AsyncCommand SignUpCommand { get; set; }

        IFirebaseAuth auth;

        public LoginViewModel()
        {
            auth = DependencyService.Get<IFirebaseAuth>();
            LoginCommand = new AsyncCommand(LoginFunc);
            SignUpCommand = new AsyncCommand(SignUpFunc);
        }

        async Task SignUpFunc()
        {
            await Shell.Current.GoToAsync("///signup");
        }

        async Task LoginFunc()
        {

            string Token = await auth.LoginWithEmailPassword(Email, Password);
            if (Token != "")
            {
                await SecureStorage.SetAsync("UserEmail", Email);
                await Shell.Current.GoToAsync("///home");
            }
            else
            {
                await DisplayAlert("Login Failed", "Something went wrong. Try again!");
            }

            

        }

       

    }
}
