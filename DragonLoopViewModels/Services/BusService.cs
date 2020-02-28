using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class BusService
    {
        private const string UrlPath = "/api/bus";
        private readonly string UrlBase;

        public BusService(string urlBase)
            => UrlBase = urlBase;

        public async Task<IEnumerable<Bus>> GetBusesAsync()
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = UrlPath;
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Bus>>(uri);
        }
    }
}
