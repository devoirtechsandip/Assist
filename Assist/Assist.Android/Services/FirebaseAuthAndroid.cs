using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Assist.Droid.Services;
using Assist.Services;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthAndroid))]
namespace Assist.Droid.Services
{
    public class FirebaseAuthAndroid : IFirebaseAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public bool SignUpWithEmailPassword(string email, string password)
        {
            try
            {
                var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);

                return signUpTask.IsSuccessful;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SignOut()
        {
            FirebaseAuth.Instance.SignOut();
        }
    }
}