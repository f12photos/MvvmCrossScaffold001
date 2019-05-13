using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using Acr.UserDialogs;
using MvvmCross.Logging;

namespace MvvmCrossScaffold001.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxLog _log;

        public BaseViewModel()
        {

        }

        public static void DisplayToast(string iMsg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(iMsg));
        }
        public static void DisplayAlert(string iTitle, string iMsg)
        {
            Acr.UserDialogs.AlertConfig.DefaultOkText = "OK";
            UserDialogs.Instance.Alert(iMsg, iTitle);
        }
    }
}
