using System;
using System.IO;
using MvvmCrossScaffold001.Core;
using MvvmCrossScaffold001.Core.Services.Itf;
using Xamarin.Essentials;

namespace MvvmCrossScaffold001.iOS.Services.Impl
{
    public class UtilityService : IUtilityService
    {
        public UtilityService()
        {
        }

        public bool FileExists(string iFileName)
        {
            var mainDir = FileSystem.AppDataDirectory;
            var dbPath = Path.Combine(mainDir, iFileName);
            if (System.IO.File.Exists(dbPath))
                return true;
            else
                return false;
        }
    }
}
