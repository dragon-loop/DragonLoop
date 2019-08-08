using DrexelBusModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrexelBusApp.Services
{
    public class RouteService : IDataService<Route>
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        public async Task<Route> GetItemAsync(string id)
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = $"/api/route/{id}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<Route>(uri);
        }

        public async Task<IEnumerable<Route>> GetItemsAsync()
        {
            UriBuilder builder = new UriBuilder(Settings.UrlBase);
            builder.Path = "/api/route";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Route>>(uri);
        }
    }
}
