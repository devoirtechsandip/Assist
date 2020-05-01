using Assist.Models;
using Assist.Services;
using Assist.Views;
using Microsoft.AppCenter.Crashes;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class NewAccountViewModel : ViewModelBase
    {
        #region Properties
        public AsyncCommand SignUp { get; }
        public AsyncCommand LoginCommand { get; }



        private string name;
        public string Name
    {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
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

        IFirebaseAuth auth;

        #endregion
        public NewAccountViewModel()
        {
            auth = DependencyService.Get<IFirebaseAuth>();
            SignUp = new AsyncCommand(SignUpFunc);
            LoginCommand = new AsyncCommand(LoginFunc);
        }

       

        #region Command Functions
        async Task SignUpFunc()
        {
            if (!(await CheckConnectivity("Check connectivity", "Unable to signup, please check internet and try again")))
                return;

            bool created = auth.SignUpWithEmailPassword(Email, Password);
            if (created)
            {
                await SecureStorage.SetAsync("UserEmail", Email);
                await DisplayAlert("Success", "Welcome to our system. Log in to have full access");
                await Shell.Current.GoToAsync("///home");
            }
            else
            {
                await DisplayAlert("Sign Up Failed", "Something went wrong. Try again!");
            }


        }

        async Task LoginFunc()
        {
            await Shell.Current.GoToAsync("///login");
        }


        #endregion
    }
}
