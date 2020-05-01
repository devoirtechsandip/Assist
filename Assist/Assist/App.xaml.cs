using Assist.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assist
{
    public partial class App : Application
    {
        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQyMjgwQDMxMzgyZTMxMmUzMG44dERXTUprUGVlSzVIVHl4VFdsbGphd1VzMEY3NjF6WFg2L294aXF1aEk9");

            

            InitializeComponent();

#if DEBUG
            Preferences.Set("wsurl", "http://localhost:60172/api/");
#else
           
#endif

            MainPage = new ShellPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=d946c06b-6fe0-4780-bd51-7fb907aab9d7;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
