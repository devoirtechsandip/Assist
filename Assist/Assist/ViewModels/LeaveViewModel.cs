using Microsoft.AppCenter.Crashes;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assist.ViewModels
{
    public class LeaveViewModel : ViewModelBase
    {
        #region Properties
        public AsyncCommand Submit { get; }

        

        #endregion
        public LeaveViewModel()
        {
            Submit = new AsyncCommand(SubmitFunc);
        }

        #region Command Functions
        async Task SubmitFunc()
        {
            if (!(await CheckConnectivity("Check connectivity", "Unable to submit leave request, please check internet and try again")))
                return;

            try
            {
                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Sync Error", ex.Message);
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }


        }
        #endregion
    }
}
