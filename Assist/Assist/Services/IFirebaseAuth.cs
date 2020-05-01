using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assist.Services
{
    public interface IFirebaseAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        bool SignUpWithEmailPassword(string email, string password);
        void SignOut();
    }
}
