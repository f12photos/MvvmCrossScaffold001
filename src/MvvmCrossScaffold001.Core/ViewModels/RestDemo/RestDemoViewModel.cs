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

        private readonly IHttpService _httpSvc;
        private readonly IBaseHttpService _baseHttpSvc;

        private readonly IMvxNavigationService _navigationService;

        public RestDemoViewModel(IMvxNavigationService navigationService
            , IMvxJsonConverter mvxJsonConverter
            , IRestClient restClient
            , IMvxRestClient mvxRestClient
            , IMvxJsonRestClient mvxJsonRestClient
            , IHttpService httpService
            , IBaseHttpService baseHttpService)
        {
            _navigationService = navigationService;

            _mvxJsonConverter = mvxJsonConverter;
            _restClient = restClient;
            _mvxRestClient = mvxRestClient;
            _mvxJsonRestClient = mvxJsonRestClient;

            _httpSvc = httpService;
            _baseHttpSvc = baseHttpService;

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
            // https://stackoverflow.com/questions/38784741/working-example-of-mvxrestclient-makerequestasync-with-mvxjsonrequest
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

            Message = "Mvx Json Rest Client : ";
            Message += response.StatusCode.ToString();

            // Check response.StatusCode if matches your expected status code
            if (null != response.Result)
            {
                UserResponse user = response.Result;
                Message += " " + _mvxJsonConverter.SerializeObject(user);
            }
            else
            {
                // do something in the case of error/time-out/unexpected response code
                Message += "Error : unrecognized response ";
            }
        }

        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public IMvxCommand ModernHttpClientCommand
        {
            get { return new MvxAsyncCommand(ModernHttpClientTask); }
        }

        public async Task ModernHttpClientTask()
        {
            // based on star wars example
            await Task.Delay(10);
            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;
            Message = "Modern Http Client : ";

            UserRequest request = new UserRequest
            {
                Title = "foo",
                Body = "bar",
                UserId = 1
            };

            string strUrl = "https://jsonplaceholder.typicode.com/posts";
            var response = await _baseHttpSvc.PostAsync(strUrl, request).ConfigureAwait(false);
            if(null != response)
            {
                string strReponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Message += response.StatusCode.ToString();
                Message += " " + strReponse;
            }
        }
    }
}
