using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class BusService
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        private readonly string UrlBase;

        public BusService(string urlBase)
            => UrlBase = urlBase;

        public async Task<Bus> GetBusAsync(string id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"/api/bus/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Bus>(uri);
        }

        public async Task<IEnumerable<Bus>> GetBusesAsync()
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = "/api/bus";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Bus>>(uri);
        }
    }
}
