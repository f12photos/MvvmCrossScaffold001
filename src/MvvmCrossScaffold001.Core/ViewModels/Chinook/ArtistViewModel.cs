using System;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class ArtistViewModel : ChinookBaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);
        private readonly IMvxNavigationService _navSvc;
        private readonly IArtistService _artistSvc;

        public ArtistViewModel(IMvxNavigationService navigationService, IArtistService artistService)
        {

            _navSvc = navigationService;

            _artistSvc = artistService;

            var items = _artistSvc.GetAll();

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

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(AddTask); }
        }

        public async Task AddTask()
        {
            await Task.Delay(10);
            var result = await _navSvc.Navigate<ArtistAddViewModel, Artist>();
            if(null != result)
            {
                var foundArtist = _items.FirstOrDefault(x => x.Name == result.Name);
                if(null == foundArtist)
                {
                    Items.Insert(0, result);
                    //await RaisePropertyChanged(() => Items);
                    // add this to the observarble list
                    //_items.Insert(0, result);
                }
            }
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand<Artist> ArtistSelectedCommand { get { return new MvxAsyncCommand<Artist>(ArtistSelected); } }
        private async Task ArtistSelected(Artist selectedArtist)
        {
            await Task.Delay(50);
            //DisplayAlert("Artist Selected ", selectedArtist.Name);

            var result = await _navSvc.Navigate<ArtistEditViewModel, Artist, Artist>(selectedArtist);

            if (result != null)
            {
                var foundArtist = _items.FirstOrDefault(x => x.Name == selectedArtist.Name);
                if(null != foundArtist)
                {
                    foundArtist.Name = "***" + result.Name;
                    //
                }
            }
        }
    }
}
