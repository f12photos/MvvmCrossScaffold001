using System;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IAlbumService : IBaseService<Album>
    {
        void AddAlbum(Album t);
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------

    public class AlbumService : BaseService<Album>, IAlbumService
    {
        public AlbumService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
        }

        public void AddAlbum(Album t)
        {
            //throw new NotImplementedException();
            Save(t);
        }
    }
}
