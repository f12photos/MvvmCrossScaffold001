using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Network.Rest;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.RestDemo
{
    public class RestDemoViewModel : BaseViewModel
    {
        //private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);


        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxJsonRestClient _restClient;

        public RestDemoViewModel(IMvxNavigationService navigationService, IMvxJsonRestClient restClient)
        {
            _navigationService = navigationService;
            _restClient = restClient;

            //Items = new MvxObservableCollection<Artist>();
            //_items.AddRange(items);
        }

        /*
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
        */

        public IMvxCommand AddCommand
        {
            get { return new MvxAsyncCommand(PostSampleAsync); }
        }


        public async Task AddTask()
        {
            await Task.Delay(10);
            //var result = await _navigationService.Navigate<TrackAddViewModel, Track>();
            //var strTrackName = result.Name;
        }

        public async Task PostSampleAsync()
        {
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

           // var client = Mvx.Resolve<IMvxJsonRestClient>();
            var response = await _restClient.MakeRequestForAsync<UserResponse>(request);

            // Check response.StatusCode if matches your expected status code
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // interrogate the response object
                UserResponse user = response.Result;
            }
            else
            {
                // do something in the case of error/time-out/unexpected response code
            }
        }
    }
}
