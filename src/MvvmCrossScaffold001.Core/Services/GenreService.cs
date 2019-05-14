using System;
using MvvmCrossScaffold001.Core.Models;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IGenreService : IBaseService<Genre>
    {

    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
        }
    }
}
