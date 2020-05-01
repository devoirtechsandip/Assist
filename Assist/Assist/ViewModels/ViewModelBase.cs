using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        //DataService dataService;
        //public DataService DataService => dataService ??= DependencyService.Get<DataService>();


        public async Task<bool> CheckConnectivity(string title, string message)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                return true;

            await DisplayAlert(title, message);
            return false;
        }

        public Task DisplayAlert(string title, string message) =>
            Application.Current.MainPage.DisplayAlert(title, message, "OK");
        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel) =>
            Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }
}
