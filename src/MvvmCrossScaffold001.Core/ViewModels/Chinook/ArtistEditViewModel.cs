using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class ArtistEditViewModel : BaseViewModel<Artist, Artist>
    {
        IMvxNavigationService _navSvc;
        IArtistService _artistSvc;
        IAlbumService _albumSvc;
        private Artist selectedArtist;
        public ArtistEditViewModel(IMvxNavigationService navigationService, IArtistService artistService, IAlbumService albumSvc)
        {
            _navSvc = navigationService;
            _artistSvc = artistService;
            _albumSvc = albumSvc;

            _albums = new MvxObservableCollection<Album>();
        }

        public override void Prepare(Artist parameter)
        {
            //throw new NotImplementedException();
            _name = parameter.Name;
            selectedArtist = parameter;

            _albums.Clear();
            var items = _albumSvc.GetAlbumsFromArtist(parameter.Id);
            _albums.AddRange(items);
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        private MvxObservableCollection<Album> _albums;
        public MvxObservableCollection<Album> Albums
        {
            get
            {
                return _albums;
            }
            set
            {
                _albums = value;
                RaisePropertyChanged(() => Albums);
            }
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(AddAsync); }
        }

        private async Task AddAsync()
        {
            selectedArtist.Name = _name;
            //throw new NotImplementedException();
            await _navSvc.Close(this, selectedArtist);
        }
    }
}
