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
    public class AlbumViewModel : ChinookBaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);


        private readonly IMvxNavigationService _navigationService;
        private readonly IAlbumService _albumSvc;

        public AlbumViewModel(IMvxNavigationService navigationService, IAlbumService albumService)
        {
            _albumSvc = albumService;
            _navigationService = navigationService;
            var items = _albumSvc.GetAll();

            Items = new MvxObservableCollection<Album>();

            _items.AddRange(items);
        }

        private MvxObservableCollection<Album> _items;
        public MvxObservableCollection<Album> Items
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

        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(AddAsync); }
        }


        public async Task AddAsync()
        {
            //simulate a call to the server
            await Task.Delay(50);




            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;
        }
    }
}
