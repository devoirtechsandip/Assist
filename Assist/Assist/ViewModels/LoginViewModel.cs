
using Assist.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public Xamarin.Forms.Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Xamarin.Forms.Command(LoginFunc);
        }


        //Google Authentication code

        OAuth2Authenticator oAuth2Authenticator;
       

        public static EventHandler OnPresenter;


        //Account account;

        //AccountStore store = null;

        //const string ServiceId = "Assist";
        void LoginFunc()
        {
            
        }

       

    }
}
