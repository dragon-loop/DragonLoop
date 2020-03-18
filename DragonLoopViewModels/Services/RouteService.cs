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
            var builder = new UriBuilder(UrlBase);
            builder.Path = UrlPath;
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Route>>(uri);
        }

        public async Task<IEnumerable<Bus>> GetBusesAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/buses";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Bus>>(uri);
        }

        public async Task<IEnumerable<Stop>> GetStopsAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/stops";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Stop>>(uri);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/schedules";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Schedule>>(uri);
        }

        public async Task<IEnumerable<RouteSegment>> GetRouteSegmentsAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/routesegments";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<RouteSegment>>(uri);
        }
    }
}
