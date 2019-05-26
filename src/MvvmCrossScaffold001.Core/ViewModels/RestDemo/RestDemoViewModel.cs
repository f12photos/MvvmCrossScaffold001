using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Network.Rest;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Rest;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.RestDemo
{
    // https://stackoverflow.com/questions/38784741/working-example-of-mvxrestclient-makerequestasync-with-mvxjsonrequest
    public class RestDemoViewModel : BaseViewModel
    {
        private readonly IMvxJsonConverter _mvxJsonConverter;
        private readonly IRestClient _restClient;
        private readonly IMvxRestClient _mvxRestClient;
        private readonly IMvxJsonRestClient _mvxJsonClient;

        private readonly IMvxNavigationService _navigationService;

        public RestDemoViewModel(IMvxNavigationService navigationService
            , IMvxJsonConverter mvxJsonConverter
            , IRestClient restClient
            , IMvxRestClient mvxRestClient
            , IMvxJsonRestClient mvxJsonClient)
        {
            _navigationService = navigationService;

            _mvxJsonConverter = mvxJsonConverter;
            _restClient = restClient;
            _mvxRestClient = mvxRestClient;
            _mvxJsonClient = mvxJsonClient;

            //var items = _artistService.GetAll();
            //Items = new MvxObservableCollection<Artist>();
            //_items.AddRange(items);
        }

        //private MvxObservableCollection<Artist> _items;
        //public MvxObservableCollection<Artist> Items
        //{
        //    get
        //    {
        //        return _items;
        //    }
        //    set
        //    {
        //        _items = value;
        //        RaisePropertyChanged(() => Items);
        //    }
        //}

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
