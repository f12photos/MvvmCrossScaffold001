using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCrossScaffold001.Core.ViewModels.Main;

namespace MvvmCrossScaffold001.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
