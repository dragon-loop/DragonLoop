using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopApp.Services
{
    public class StopService : IDataService<Stop>
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        public async Task<Stop> GetItemAsync(string id)
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = $"/api/Stop/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Stop>(uri);
        }

        public async Task<IEnumerable<Stop>> GetItemsAsync()
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = "/api/Stop";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Stop>>(uri);
        }
    }
}
