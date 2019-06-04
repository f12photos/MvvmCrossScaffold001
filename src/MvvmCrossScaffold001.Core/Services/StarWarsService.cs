using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCrossScaffold001.Core.Models;
using MvvmCrossScaffold001.Core.Rest;

namespace MvvmCrossScaffold001.Core.Services
{
    public interface IStarWarsPeopleService
    {
        Task<PagedResult<StarWarsPerson>> GetPeopleAsync(string url = null);

        Task<StarWarsPerson> GetPersonAsync();
    }

    //--------------------------------------------------------------------------
    //--------------------------------------------------------------------------
    public class StarWarsPeopleService : IStarWarsPeopleService
    {
        private readonly IRestClient _restClient;

        public StarWarsPeopleService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<StarWarsPerson>> GetPeopleAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<StarWarsPerson>>($"{Constants.BaseStarWarsUrl}/people/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<StarWarsPerson>>(url, HttpMethod.Get);
        }

        public Task<StarWarsPerson> GetPersonAsync()
        {
            return _restClient.MakeApiCall<StarWarsPerson>($"{Constants.BaseStarWarsUrl}/people/1/", HttpMethod.Get);
        }

        private PagedResult<StarWarsPerson> GetMockedPeople()
        {
            return new PagedResult<StarWarsPerson>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<StarWarsPerson>
                {
                    new StarWarsPerson
                    {
                        Name = "Master Yoda",
                        SkinColor = "Green",
                        Height = "65"
                    },
                    new StarWarsPerson
                    {
                        Name = "Obi-Wan Kenobi",
                        Mass = "80"
                    },
                    new StarWarsPerson
                    {
                        Name = "Master Windu",
                        Height = "165",
                        Mass = "85"
                    }
                }
            };
        }
    }
}
