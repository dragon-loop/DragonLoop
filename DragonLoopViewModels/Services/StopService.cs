using DragonLoopModels;
using System;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class StopService
    {
        private const string UrlPath = "/api/stop";
        private readonly string UrlBase;

        public StopService(string urlBase)
            => UrlBase = urlBase;

        public async Task<Bus> GetNextBusAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/nextbus";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<Bus>(uri);
        }

        public async Task<TimeSpan> GetNextExpectedTimeAsync(int id, TimeSpan time)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}/nextexpectedtime/{time}";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<TimeSpan>(uri);
        }

        public async Task<TimeSpan> GetExpectedTimeAsync(int stopId, int tripId)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{stopId}/expectedtime/{tripId}";
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<TimeSpan>(uri);
        }
    }
}
