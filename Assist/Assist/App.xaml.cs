using Assist.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assist
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SocialLoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
