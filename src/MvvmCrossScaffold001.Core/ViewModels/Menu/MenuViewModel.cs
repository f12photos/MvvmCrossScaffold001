using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.WebBrowser;
using MvvmCrossScaffold001.Core.Services.Itf;
using MvvmCrossScaffold001.Core.ViewModels.Chinook;
using MvvmCrossScaffold001.Core.ViewModels.Color;
using MvvmCrossScaffold001.Core.ViewModels.FFImage;
using MvvmCrossScaffold001.Core.ViewModels.Lifecycle;
using MvvmCrossScaffold001.Core.ViewModels.Main;
using MvvmCrossScaffold001.Core.ViewModels.RestDemo;
using MvvmCrossScaffold001.Core.ViewModels.Settings;
using MvvmCrossScaffold001.Core.ViewModels.Spinner;
using MvvmCrossScaffold001.Core.ViewModels.TipCalculator;
using MvvmCrossScaffold001.Core.ViewModels.WebView;

namespace MvvmCrossScaffold001.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        readonly IMvxNavigationService _navigationService;
        readonly IUtilityService _utlSvc;

        public IMvxAsyncCommand ShowHomeCommand { get; private set; }
        public IMvxAsyncCommand ShowSettingsCommand { get; private set; }
        public IMvxAsyncCommand ShowChinookCommand { get; private set; }
        public IMvxAsyncCommand ShowTipCommand { get; private set; }
        public IMvxAsyncCommand ShowLifecycleCommand { get; private set; }
        public IMvxAsyncCommand ShowFFImageCommand { get; private set; }
        public IMvxAsyncCommand ShowRestDemoCommand { get; private set; }
        public IMvxAsyncCommand ShowSpinnerCommand { get; private set; }
        public IMvxAsyncCommand ShowColorCommand { get; private set; }
        public IMvxAsyncCommand ShowWebViewCommand { get; private set; }



        public MenuViewModel(IMvxNavigationService navigationService, IUtilityService utlSvc)
        {
            _navigationService = navigationService;
            _utlSvc = utlSvc;

            ShowHomeCommand = new MvxAsyncCommand(NavigateToHomeAsync);
            ShowSettingsCommand = new MvxAsyncCommand(NavigateToSettingsAsync);
            ShowChinookCommand = new MvxAsyncCommand(NavigateToChinookAsync);
            ShowTipCommand = new MvxAsyncCommand(NavigateToTipAsync);
            ShowLifecycleCommand = new MvxAsyncCommand(NavigateToLifecycleAsync);
            ShowFFImageCommand = new MvxAsyncCommand(NavigateToFFImageAsync);
            ShowRestDemoCommand = new MvxAsyncCommand(NavigateToRestDemoAsync);
            ShowSpinnerCommand = new MvxAsyncCommand(NavigateToSpinnerAsync);
            ShowColorCommand = new MvxAsyncCommand(NavigateToColorAsync);
            ShowWebViewCommand = new MvxAsyncCommand(NavigateToWebviewAsync);
        }

        private Task NavigateToHomeAsync()
        {
            return _navigationService.Navigate<MainViewModel>();
        }

        private Task NavigateToSettingsAsync()
        {
            return _navigationService.Navigate<SettingsViewModel>();
        }

        private Task NavigateToChinookAsync()
        {
            return _navigationService.Navigate<ChinookViewModel>();
        }

        private Task NavigateToTipAsync()
        {
            return _navigationService.Navigate<TipViewModel>();
        }

        private Task NavigateToLifecycleAsync()
        {
            return _navigationService.Navigate<Next0ViewModel>();
        }

        private Task NavigateToFFImageAsync()
        {
            return _navigationService.Navigate<FFImageViewModel>();
        }

        private Task NavigateToRestDemoAsync()
        {
            return _navigationService.Navigate<RestDemoViewModel>();
        }

        private Task NavigateToSpinnerAsync()
        {
            return _navigationService.Navigate<SpinnerViewModel>();
        }

        private Task NavigateToColorAsync()
        {
            return _navigationService.Navigate<ColorViewModel>();
        }

        private Task NavigateToWebviewAsync()
        {
            return _navigationService.Navigate<WebViewViewModel>();
        }

        public IMvxCommand ShowOnWeb
        {
            get
            {
                var strUrl = _utlSvc.GetFileFromBundle("Tamarin", "pdf");
                return new MvxCommand(() =>
                    Mvx.IoCProvider.Resolve<IMvxWebBrowserTask>().ShowWebPage(strUrl));
            }
        }
    }
}
