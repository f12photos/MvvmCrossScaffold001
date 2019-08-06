using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.ViewModels.Main;

namespace MvvmCrossScaffold001.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            //CreatableTypes()
            //    .EndingWith("Client")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            //CreatableTypes()
            //    .EndingWith("Converter")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            //RegisterAppStart<MainViewModel>();

            RegisterCustomAppStart<AppStart>();
        }
    }

    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication app, IMvxNavigationService navService)
            : base(app, navService)
        {

        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<MainViewModel>();
        }
    }
}