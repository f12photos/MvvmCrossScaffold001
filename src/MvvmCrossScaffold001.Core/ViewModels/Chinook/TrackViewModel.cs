using System;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class TrackViewModel : ChinookBaseViewModel
    {
        private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        private readonly ITrackService _trackService;

        public TrackViewModel(ITrackService trackService)
        {
            _trackService = trackService;

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
    }
}
