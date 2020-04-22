using AssistApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistApp.ViewModels
{
    public class AddContactViewModel : BindableBase
    {
        public AddContactViewModel()
        {

     
        }

        private string _txtName;
        public string txtName
        {
            get { return _txtName; }
            set { SetProperty(ref _txtName, value); }
        }

        private string _txtNo;
        public string txtNo
        {
            get { return _txtNo; }
            set { SetProperty(ref _txtNo, value); }
        }

        private DelegateCommand _SaveCommand;
        public DelegateCommand SaveCommand =>
            _SaveCommand ?? (_SaveCommand = new DelegateCommand(ExecuteSaveCommand));

        async void ExecuteSaveCommand()
        {

            var _PhoneNos = new PhoneNos();
            _PhoneNos.ContactName = txtName;
            _PhoneNos.ContactNo = txtNo;
            var result = await App.Database.SavePhoneNosAsync(_PhoneNos);

            if (result > 0)
            { 
            }
            

        }
    }
}
