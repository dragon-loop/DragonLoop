using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class RouteService
    {
        private const string UrlPath = "/api/route";
        private readonly string UrlBase;

        public RouteService(string urlBase)
            => UrlBase = urlBase;

        public async Task<IEnumerable<Route>> GetRoutesAsync()
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = UrlPath;
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Route>>(uri);
        }

        public async Task<IEnumerable<Bus>> GetBusesAsync(int id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/buses";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Bus>>(uri);
        }

        public async Task<IEnumerable<Stop>> GetStopsAsync(int id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/stops";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Stop>>(uri);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync(int id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/schedules";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Schedule>>(uri);
        }

        public async Task<IEnumerable<RouteSegment>> GetRouteSegmentsAsync(int id)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/routesegments";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<RouteSegment>>(uri);
        }
    }
}
