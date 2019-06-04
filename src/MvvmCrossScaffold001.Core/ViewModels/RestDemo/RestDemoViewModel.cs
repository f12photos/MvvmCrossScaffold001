using System;
using System.Net.Http;
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
using Newtonsoft.Json;

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

        private UserRequest _request;
        private string _strUrl;

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

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
            _request = new UserRequest
            {
                Title = "foo",
                Body = "bar",
                UserId = 1
            };

            _strUrl = "https://jsonplaceholder.typicode.com/posts";
        }

        public override async Task Initialize()
        {
            await base.Initialize();


            // do the heavy work here
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

            try
            {
                //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
                //var strTrackName = result.Name;
            
                var response = await _restClient.MakeApiCall<UserResponse>(_strUrl, HttpMethod.Post, _request);

                Message = "Rest : ";
                if (null != response)
                {
                    Message += _mvxJsonConverter.SerializeObject(response);
                }
            }
            catch(Exception ex)
            {
                Message = "Error " + ex.Message;
            }

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
            Message = "Mvx Rest Client not implemented";

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
            var request = new MvxJsonRestRequest<UserRequest>(_strUrl)
            {
                Body = _request
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

            var response = await _baseHttpSvc.PostAsync(_strUrl, _request).ConfigureAwait(false);
            if(null != response)
            {
                string strReponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Message += response.StatusCode.ToString();
                Message += " " + strReponse;

                var userResponse0 = JsonConvert.DeserializeObject(strReponse);

                var userResponse1 = _mvxJsonConverter.DeserializeObject(typeof(UserResponse), strReponse);

            }
        }
    }
}
