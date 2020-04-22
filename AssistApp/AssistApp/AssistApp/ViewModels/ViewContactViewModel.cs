using AssistApp.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Essentials;

namespace AssistApp.ViewModels
{
    public class ViewContactViewModel : BindableBase, INavigationAware
    {
        public ViewContactViewModel()
        {

            GetContactList();
        }

        private ObservableRangeCollection<PhoneNos> _lst_PhoneNos;
        public ObservableRangeCollection<PhoneNos> lst_PhoneNos
        {
            get { return _lst_PhoneNos; }
            set { SetProperty(ref _lst_PhoneNos, value); }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }

        private async void GetContactList()
        {
            //UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black);

            var result = await App.Database.GetPhoneNosAsync();

            if (result.Count > 0)
            {
                lst_PhoneNos = new ObservableRangeCollection<PhoneNos>();
                lst_PhoneNos.ReplaceRange(result);
            }

            //UserDialogs.Instance.HideLoading();
        }

        private PhoneNos _SelectedPhone;
        public PhoneNos SelectedPhone
        {
            get { return _SelectedPhone; }
            set { SetProperty(ref _SelectedPhone, value); }
        }

        private DelegateCommand<PhoneNos> _NoTapped;
        public DelegateCommand<PhoneNos> NoTapped =>
            _NoTapped ?? (_NoTapped = new DelegateCommand<PhoneNos>(ExecuteNoTapped, CanExecuteNoTapped));

        void ExecuteNoTapped(PhoneNos parameter)
        {
            var item = SelectedPhone;
        }

        bool CanExecuteNoTapped(PhoneNos parameter)
        {
            return true;
        }
    }
}
