using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.ViewModels.Lifecycle
{
    public class Next0ViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public Next0ViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override async Task Initialize()
        {
            await base.Initialize();


            // do the heavy work here
        }


        public ICommand Next1Command
        {
            get { return new MvxAsyncCommand(SomeMethod1); }
        }

        public ICommand Next2Command
        {
            get { return new MvxAsyncCommand(SomeMethod2); }
        }

        public async Task SomeMethod1()
        {
            // pass object to next view model
            await _navigationService.Navigate<Next1ViewModel, MyObject>(new MyObject());
        }

        public async Task SomeMethod2()
        {
            // pass object to next view model, and result

            var result = await _navigationService.Navigate<Next2ViewModel, MyObject, MyReturnObject>(new MyObject());
            //Do something with the result MyReturnObject that you get back
        }
    }

    public class Next1ViewModel : MvxViewModel<MyObject>
    {
        private MyObject _myObject;

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(MyObject parameter)
        {
            // receive and store the parameter here
            _myObject = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            // do the heavy work here
        }
    }

    public class Next2ViewModel : MvxViewModel<MyObject, MyReturnObject>
    {
        private readonly IMvxNavigationService _navigationService;

        private MyObject _myObject;

        public Next2ViewModel(IMvxNavigationService navigation)
        {
            _navigationService = navigation;
        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(MyObject parameter)
        {
            // receive and store the parameter here
            _myObject = parameter;
        }

        public override async Task Initialize()
        {
            //Do heavy work and data loading here
            await base.Initialize();
        }

        public async Task SomeMethodToClose()
        {
            await _navigationService.Close(this, new MyReturnObject());
        }
    }
}
