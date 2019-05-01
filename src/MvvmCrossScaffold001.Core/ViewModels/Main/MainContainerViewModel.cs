using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCrossScaffold001.Core.ViewModels.Menu;

namespace MvvmCrossScaffold001.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowMenuCommand { get; private set; }

        public MainContainerViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowMenuCommand = new MvxAsyncCommand(NavigateToMenuAsync);
        }

        private Task NavigateToMenuAsync()
        {
            return _navigationService.Navigate<MenuViewModel>();
        }
    }
}
