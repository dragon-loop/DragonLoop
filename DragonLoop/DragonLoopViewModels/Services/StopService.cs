using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class StopService
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        private readonly string UrlBase;

        public StopService(string urlBase)
            => UrlBase = urlBase;

        public async Task<Stop> GetStopAsync(string id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"/api/stop/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Stop>(uri);
        }

        public async Task<IEnumerable<Stop>> GetStopsAsync()
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = "/api/stop";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Stop>>(uri);
        }
    }
}
