using System;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IMediaTypeService : IBaseService<MediaType>
    {

    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class MediaTypeService : BaseService<MediaType>, IMediaTypeService
    {
        public MediaTypeService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
        }
    }
}
