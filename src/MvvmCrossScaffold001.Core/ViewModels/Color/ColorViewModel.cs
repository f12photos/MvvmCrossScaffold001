using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.UI;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Color
{
    public class ColorViewModel : BaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        private readonly IMvxNavigationService _navigationService;
        //private readonly IMvxNativeColor _color;

        public ColorViewModel(IMvxNavigationService navigationService)
        {

            _navigationService = navigationService;
            //_color = color;
        }

        public MvxColor CurrentColor { get; set; }

        //--------------------------------------------
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
