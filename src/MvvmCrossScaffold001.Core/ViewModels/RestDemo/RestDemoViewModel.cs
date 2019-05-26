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

    public class RestDemoViewModel : BaseViewModel
    {
        private readonly IMvxJsonConverter _mvxJsonConverter;
        private readonly IRestClient _restClient;
        private readonly IMvxRestClient _mvxRestClient;
        private readonly IMvxJsonRestClient _mvxJsonRestClient;

        private readonly IMvxNavigationService _navigationService;

        public RestDemoViewModel(IMvxNavigationService navigationService
            , IMvxJsonConverter mvxJsonConverter
            , IRestClient restClient
            , IMvxRestClient mvxRestClient
            , IMvxJsonRestClient mvxJsonRestClient)
        {
            _navigationService = navigationService;

            _mvxJsonConverter = mvxJsonConverter;
            _restClient = restClient;
            _mvxRestClient = mvxRestClient;
            _mvxJsonRestClient = mvxJsonRestClient;

            //var items = _artistService.GetAll();
            //Items = new MvxObservableCollection<Artist>();
            //_items.AddRange(items);
        }


        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
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
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand RestCommand
        {
            get { return new MvxAsyncCommand(RestTask); }
        }

        public async Task RestTask()
        {
            // based on star wars example
            await Task.Delay(10);
            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;

            Message = "Rest Task : ";
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand MvxRestCommand
        {
            get { return new MvxAsyncCommand(MvxRestTask); }
        }

        public async Task MvxRestTask()
        {
            // based on star wars example
            await Task.Delay(10);
            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;
            Message = "Mvx Rest Task : ";
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand MvxJsonRestCommand
        {
            get { return new MvxAsyncCommand(MvxJsonRestTask); }
        }

        public async Task MvxJsonRestTask()
        {
            // // https://stackoverflow.com/questions/38784741/working-example-of-mvxrestclient-makerequestasync-with-mvxjsonrequest
            var request = new MvxJsonRestRequest<UserRequest>
                ("http://jsonplaceholder.typicode.com/posts")
            {
                Body = new UserRequest
                {
                    Title = "foo",
                    Body = "bar",
                    UserId = 1
                }
            };

            var response = await _mvxJsonRestClient.MakeRequestForAsync<UserResponse>(request);

            // Check response.StatusCode if matches your expected status code
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // interrogate the response object
                UserResponse user = response.Result;
                Message = "Mvx Json Rest Client Return : " + _mvxJsonConverter.SerializeObject(user);
            }
            else
            {
                // do something in the case of error/time-out/unexpected response code
                Message = "Error : Mvx Json Rest Client Return = " + response.StatusCode.ToString();
            }
        }
    }
}
