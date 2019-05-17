using System;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.Services
{

    public interface ITrackService : IBaseService<Track>
    {
        void AddTrack(Track t);
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------

    public class TrackService : BaseService<Track>, ITrackService
    {
        public TrackService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
        }

        public void AddTrack(Track t)
        {
            Save(t);
        }
    }
}
