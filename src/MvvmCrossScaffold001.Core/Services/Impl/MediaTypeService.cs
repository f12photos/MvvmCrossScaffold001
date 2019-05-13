using System;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Services.Itf;

namespace MvvmCrossScaffold001.Core.Services.Impl
{
    public class MediaTypeService : BaseService<MediaType>, IMediaTypeService
    {
        public MediaTypeService(IRepositoryService repoSvc) : base (repoSvc)
        {
        }
    }
}
