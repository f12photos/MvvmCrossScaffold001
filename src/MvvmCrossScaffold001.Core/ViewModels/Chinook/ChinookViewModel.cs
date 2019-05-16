using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MvvmCrossScaffold001.Core.Services;
using MvvmCross.Navigation;
using MvvmCross;
using System.Windows.Input;
using MvvmCross.Commands;
using System.Reflection;
using MvvmCross.IoC;
using MvvmCross.Converters;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    public class StripConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Replace((string)parameter, string.Empty);
        }
    }
    //public class ChinookViewModel : BaseViewModel
    //{
    //    readonly IMediaTypeService _mediaTypeSvc;
    //    readonly IGenreService _genreSvc;
    //    public ChinookViewModel(IMediaTypeService mediaTypeService, IGenreService genreSvc)
    //    {
    //        _mediaTypeSvc = mediaTypeService;
    //        _genreSvc = genreSvc;

    //        var all = _mediaTypeSvc.GetAll().ToList();
    //        var types = all.Select(x => x.Name).ToList();

    //        var allgen = _genreSvc.GetAll().ToList();
    //        var genTypes = allgen.Select(x => x.Name).ToList();
    //    }
    //}

    public class ChinookViewModel : BaseViewModel
    {
        // same as FirstViewModel in ApiExample
        private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        public ChinookViewModel(IChinookService chinookService)
        {
            Tests = chinookService.All;
        }

        private IList<Type> _tests;

        public IList<Type> Tests
        {
            get { return _tests; }
            set { _tests = value; RaisePropertyChanged(() => Tests); }
        }

        public ICommand GotoTestCommand
        {
            get { return new MvxAsyncCommand<Type>(async type => await _navigationService.Value.Navigate(type)); }
        }
    }
}