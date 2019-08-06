
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.WebView
{
    public class WebViewViewModel : BaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        private readonly IMvxNavigationService _navigationService;

        public WebViewViewModel(IMvxNavigationService navigationService)
        {

            _navigationService = navigationService;
        }

        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(AddTask); }
        }

        public async Task AddTask()
        {
            await Task.Delay(10);
            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;
        }
    }
}
