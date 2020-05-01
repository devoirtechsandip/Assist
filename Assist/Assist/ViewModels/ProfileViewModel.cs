using Assist.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assist.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        //public Profile Profile { get; }

            public AsyncCommand SignOutCommand { get; }
        IFirebaseAuth auth;
        public ProfileViewModel()
        {
            //Profile = DataService.GetProfile();
            //Profile.SaveProfileAction = SaveProfile;
            auth = DependencyService.Get<IFirebaseAuth>();
            SignOutCommand = new AsyncCommand(SignOutFunc);
        }

        async Task SignOutFunc()
        {
            auth.SignOut();
            await Shell.Current.GoToAsync("///login");
        }



        //void SaveProfile()
        //{
        //    DataService.SaveProfile(Profile);
        //}
    }
}
