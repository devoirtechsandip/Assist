using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Assist.iOS;
using Xamarin.Forms;
using Firebase.Auth;
using Assist.iOS.Services;
using Assist.Services;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FirebaseAuthiOS))]
namespace Assist.iOS.Services
{
    public class FirebaseAuthiOS : IFirebaseAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public bool SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = Auth.DefaultInstance.CreateUserAsync(email, password);
                return signUpTask.Result != null;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void SignOut()
        {
            try
            {
                NSError error;

                var isSignedOut = Auth.DefaultInstance.SignOut(out error);
            }
            catch (Exception ex)
            {


            }
        }
    }
}