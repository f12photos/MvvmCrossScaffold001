using System;
using System.IO;
using Foundation;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Json;
using MvvmCross.Plugin.Network.Rest;
using MvvmCross.Plugin.Sidebar;
using MvvmCrossScaffold001.Core;
using MvvmCrossScaffold001.Core.Rest;
using MvvmCrossScaffold001.Core.Services;
using MvvmCrossScaffold001.Core.Services.Itf;
using MvvmCrossScaffold001.iOS.Services.Impl;
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
            var dbPath = Path.Combine(mainDir, Constants.DB_NAME);

            // SETUP IOC HERE INSTEAD OF CORE.APP

            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();

            Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();
            Mvx.IoCProvider.RegisterType<IMvxRestClient, MvxRestClient>();
            Mvx.IoCProvider.RegisterType<IMvxJsonRestClient, MvxJsonRestClient>();

            Mvx.IoCProvider.RegisterSingleton<IRepositoryService>(() => new RepositoryService(dbPath));
            var iRepoSvc = Mvx.IoCProvider.Resolve<IRepositoryService>();

            if (null != iRepoSvc)
            {
                //string dbChinookPath = NSBundle.MainBundle.PathForResource("chinook", "db");
                //iRepoSvc.CopyChinookDatabase(dbChinookPath);

                Mvx.IoCProvider.RegisterSingleton<INetworkService>(() => new iOSNetworkService());
                Mvx.IoCProvider.RegisterSingleton<IUtilityService>(() => new UtilityService());


                var iRest = Mvx.IoCProvider.Resolve<IRepositoryService>();
                //Mvx.IoCProvider.RegisterSingleton<IRestClient>(() => new RestClient());

                Mvx.IoCProvider.RegisterSingleton<ICalculationService>(() => new CalculationService());

                Mvx.IoCProvider.RegisterSingleton<IChinookService>(() => new ChinookService());
                Mvx.IoCProvider.RegisterSingleton<IMediaTypeService>(() => new MediaTypeService(iRepoSvc));
                Mvx.IoCProvider.RegisterSingleton<IGenreService>(() => new GenreService(iRepoSvc));
                Mvx.IoCProvider.RegisterSingleton<ITrackService>(() => new TrackService(iRepoSvc));
                Mvx.IoCProvider.RegisterSingleton<IAlbumService>(() => new AlbumService(iRepoSvc));
                Mvx.IoCProvider.RegisterSingleton<IArtistService>(() => new ArtistService(iRepoSvc));
<<<<<<< HEAD

                //typeof(Core.Services).Assembly.CreatableTypes()
                    //.EndingWith("Service")
                    //.AsInterfaces()
                    //.RegisterAsDynamic();
=======
>>>>>>> parent of 10861d2... WIP
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
