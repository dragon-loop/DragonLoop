using DrexelBusModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrexelBusApp.Services
{
    public class StopService : IDataService<Stop>
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        public async Task<Stop> GetItemAsync(string id)
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = $"/api/stop/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Stop>(uri);
        }

        public async Task<IEnumerable<Stop>> GetItemsAsync()
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = "/api/stop";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Stop>>(uri);
        }
    }
}
