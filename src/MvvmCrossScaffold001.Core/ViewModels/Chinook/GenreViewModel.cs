using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class GenreViewModel : ChinookBaseViewModel
    {
        private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        readonly IGenreService _genreSvc;
        public GenreViewModel(IGenreService genreSvc)
        {
            _genreSvc = genreSvc;
            var items = _genreSvc.GetAll();

            Items = new MvxObservableCollection<Genre>();

            _items.AddRange(items);

            //_items = (System.Collections.ObjectModel.ObservableCollection<MvvmCrossScaffold001.Core.Models.Genre>)_genreSvc.GetAll();
        }

        private MvxObservableCollection<Genre> _items;
        public MvxObservableCollection<Genre> Items
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

        public ICommand AddCommand
        {
            get { return new MvxCommand(() => _navigationService.Value.Navigate<GenreAddViewModel>()); }
        }
    }
}
