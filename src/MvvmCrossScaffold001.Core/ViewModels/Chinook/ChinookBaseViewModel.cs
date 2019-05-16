using System;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.Services;

namespace MvvmCrossScaffold001.Core.ViewModels.Chinook
{
    // same as TestViewModel in ApiExample
    public abstract class ChinookBaseViewModel : MvxViewModel
    {
        private readonly Lazy<IMvxNavigationService> _navigationService = new Lazy<IMvxNavigationService>(Mvx.IoCProvider.Resolve<IMvxNavigationService>);

        public ICommand NextCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    var all = Mvx.IoCProvider.Resolve<IChinookService>();
                    var next = all.NextViewModelType(this);
                    if (next == null)
                        await _navigationService.Value.Close(this);
                    else
                        await _navigationService.Value.Navigate(next);
                });
            }
        }
    }
}
