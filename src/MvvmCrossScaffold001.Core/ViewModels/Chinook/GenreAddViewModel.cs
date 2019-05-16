using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class GenreAddViewModel: ChinookBaseViewModel
    {
        readonly IGenreService _genreSvc;
        public GenreAddViewModel(IGenreService genreSvc)
        {
            _genreSvc = genreSvc;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        public ICommand AddCommand
        {
            get { return new MvxCommand(AddGenre); }
        }

        private void AddGenre()
        {
            Genre g = new Genre { Id = 0, Name = _name };
            _genreSvc.AddGenre(g);
        }
    }
}
