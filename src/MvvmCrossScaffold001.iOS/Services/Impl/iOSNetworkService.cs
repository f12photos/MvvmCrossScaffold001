using System;
using MvvmCrossScaffold001.Core.Services.Itf;

namespace MvvmCrossScaffold001.iOS.Services.Impl
{
    public class iOSNetworkService : INetworkService
    {
        public iOSNetworkService()
        {
        }

        public bool IsConnectedToServer()
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
