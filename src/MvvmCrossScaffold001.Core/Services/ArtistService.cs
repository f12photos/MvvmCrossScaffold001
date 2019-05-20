using System;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.Services
{

    public interface IArtistService : IBaseService<Artist>
    {
        void AddArtist(Artist g);
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class ArtistService : BaseService<Artist>, IArtistService
    {
        public ArtistService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
        }

        public void AddArtist(Artist g)
        {
            Save(g);
        }
    }
}
