using MazteTv.Service.Infrastructure;
using MazteTv.Service.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazteTv.Service
{
    public class MazeTvService:IMazeTvService
    {
        private readonly HttpClient client;
        public MazeTvService(HttpClient client)
        {
            this.client = client;
        }

        public Task<GetCastResponse[]?> GetCasts(int id, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"shows/{id}/cast");
            return client.Send<GetCastResponse[]?, CustomException>(httpRequest, HttpClientExtensions.SetException);
        }

        public Task<GetShowsResponse?> GetEpisodes(int id, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"episodes/{id}");
            return client.Send<GetShowsResponse?, CustomException>(httpRequest, HttpClientExtensions.SetException);
        }

        public Task<GetShowsResponse[]?> GetShows(int page, CancellationToken cancellationToken = default)
        {
            var valueCollection = new NameValueCollection
            {
                { "page", page.ToString() }
            };

            var path = HttpClientExtensions.BuildUri("shows", valueCollection);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, path);
            return client.Send<GetShowsResponse[]?, CustomException>(httpRequest, HttpClientExtensions.SetException);
        }
    }
}
