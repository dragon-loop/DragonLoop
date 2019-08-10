using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class RouteService
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        private readonly string UrlBase;

        public RouteService(string urlBase)
            => UrlBase = urlBase;

        public async Task<Route> GetRouteAsync(string id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"/api/route/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Route>(uri);
        }

        public async Task<IEnumerable<Route>> GetRoutesAsync()
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = "/api/route";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Route>>(uri);
        }
    }
}
