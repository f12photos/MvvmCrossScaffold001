﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class ArtistAddViewModel : BaseViewModelResult<Artist>
    {
        IMvxNavigationService _navSvc;
        IArtistService _artistSvc;
        public ArtistAddViewModel(IMvxNavigationService navigationService, IArtistService trackService)
        {
            _navSvc = navigationService;
            _artistSvc = trackService;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(AddAsync); }
        }

        private async Task AddAsync()
        {
            Artist newArtist = new Artist();

            newArtist.Name = _name;

            //throw new NotImplementedException();
            await _navSvc.Close(this, newArtist);
        }
    }
}
