using System;
namespace MvvmCrossScaffold001.Core.Services.Itf
{
    public interface IUtilityService
    {
        bool FileExists(string iFileName);

        string GetFileFromBundle(string iFileName, string iExt);
    }
}
