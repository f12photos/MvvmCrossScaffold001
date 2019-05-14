using System;
using System.Collections.Generic;
using System.Text;
using MvvmCrossScaffold001.Core.Services.Itf;

namespace MvvmCrossScaffold001.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IUtilityService _utilSvc;
        public MainViewModel(IUtilityService utilSvc)
        {
            _utilSvc = utilSvc;
            if(_utilSvc.FileExists(Constants.DB_NAME))
            {
                DisplayToast("Exists");
                //DisplayAlert("Success", "File does exist");
            }
            else 
            {
                //DisplayAlert("Error", "File does not exist");
            }
            //Acr.UserDialogs.UserDialogs.Instance.Alert("Alert");
        }


    }
}
