/*

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
    public class ArtistViewModel : BaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        private readonly IMvxNavigationService _navigationService;
        private readonly IArtistService _artistService;

        public TrackViewModel(IMvxNavigationService navigationService, IArtistService artistService)
        {

            _navigationService = navigationService;

            _artistService = artistService;
            var items = _artistService.GetAll();
            Items = new MvxObservableCollection<Artist>();
            _items.AddRange(items);
        }

        private MvxObservableCollection<Artist> _items;
        public MvxObservableCollection<Artist> Items
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

*/