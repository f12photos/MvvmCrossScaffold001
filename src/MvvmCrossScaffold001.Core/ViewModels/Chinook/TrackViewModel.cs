using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class TrackViewModel : ChinookBaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);


        private readonly IMvxNavigationService _navigationService;
        private readonly ITrackService _trackService;

        public TrackViewModel(IMvxNavigationService navigationService, ITrackService trackService)
        {
            _trackService = trackService;
            _navigationService = navigationService;
            var items = _trackService.GetAll();

            Items = new MvxObservableCollection<Track>();

            _items.AddRange(items);
        }

        private MvxObservableCollection<Track> _items;
        public MvxObservableCollection<Track> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public ICommand AddTrackCommand
        {
            get { return new MvxAsyncCommand(AddTrack); }
        }


        public async Task AddTrack()
        {
            // pass object to next view model, and result

            var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //Do something with the result MyReturnObject that you get back
        }
    }
}
