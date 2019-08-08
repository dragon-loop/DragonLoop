using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopApp.Services
{
    public class BusService : IDataService<Bus>
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        public async Task<Bus> GetItemAsync(string id)
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = $"/api/bus/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Bus>(uri);
        }

        public async Task<IEnumerable<Bus>> GetItemsAsync()
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = "/api/bus";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Bus>>(uri);
        }
    }
}
