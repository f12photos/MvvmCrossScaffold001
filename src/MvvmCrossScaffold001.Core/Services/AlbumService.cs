using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Rest;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IAlbumService : IBaseService<Album>
    {
        void AddAlbum(Album t);

        IEnumerable<Album> GetAlbumsFromArtist(int ArtistId);
        //Task<PagedResult<Album>> GetAlbumsAsync(string url = null);

        //Task<Album> GetAlbumAsync();
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------

    public class AlbumService : BaseService<Album>, IAlbumService
    {
        //private readonly Lazy<IRestClient> _restClient = new Lazy<IRestClient>(Mvx.IoCProvider.Resolve<IRestClient>);

        private readonly IRestClient _restClient;
        public AlbumService(IRepositoryService repoSvc) : base(repoSvc)
        {
            //repoSvc.GetData();
            //_restClient = restClient;
            _restClient = Mvx.IoCProvider.Resolve<IRestClient>();
        }

        public void AddAlbum(Album t)
        {
            //throw new NotImplementedException();
            Save(t);
        }

        public IEnumerable<Album> GetAlbumsFromArtist(int ArtistId)
        {
            var albums = GetAll().Where(x => x.ArtistId == ArtistId);
            return albums;
        }

        /*

        public Task<PagedResult<Album>> GetAlbumsAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<Album>>($"{Constants.BaseUrl}/people/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<Album>>(url, HttpMethod.Get);
        }

        public Task<Album> GetAlbumAsync()
        {
            return _restClient.MakeApiCall<Album>($"{Constants.BaseUrl}/people/1/", HttpMethod.Get);
        }

        private PagedResult<Album> GetAlbumsFromDatabase()
        {
            var albums = GetAll().ToList();
            return new PagedResult<Album>()
            {
                Count = albums.Count,
                Next = string.Empty,
                Previous = string.Empty,
                Results = albums
            };
        }
        */
    }
}
