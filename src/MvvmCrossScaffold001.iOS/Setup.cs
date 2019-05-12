using System;
using System.IO;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core;
using Xamarin.Essentials;

namespace MvvmCrossScaffold001.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
            => new MvxSidebarPresenter(ApplicationDelegate, Window);

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            //Mvx.RegisterType<IMv>

            // IOC Functions
            var mainDir = FileSystem.AppDataDirectory;
            var dbPath = Path.Combine(mainDir, "mydbName.db3");

            // SETUP IOC HERE INSTEAD OF CORE.APP
            Mvx.IoCProvider.RegisterSingleton<IRepositoryService>(() => new RepositoryService(dbPath));
            var iRepoSvc = Mvx.IoCProvider.Resolve<IRepositoryService>();

            if (null != iRepoSvc)
            {

            }
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            //return base.CreateIocOptions();
            return new MvxIocOptions
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }
    }
}
