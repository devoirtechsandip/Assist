using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CheckLogin();
        }


        async Task CheckLogin()
        {
            var UserEmail = await SecureStorage.GetAsync("UserEmail");
            if (string.IsNullOrEmpty(UserEmail))
                await Shell.Current.GoToAsync("///login");
            else
                await Shell.Current.GoToAsync("///home");
        }

    }
}
