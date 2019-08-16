using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class ScheduleService
    {
        private static RequestProvider RequestProvider = new RequestProvider();

        private readonly string UrlBase;

        public ScheduleService(string urlBase)
            => UrlBase = urlBase;

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync(int? routeId = null)
        {
            UriBuilder builder = new UriBuilder(UrlBase);
            builder.Path = "/api/schedule";
            if (routeId != null) builder.Query= $"routeid={routeId}";
            string uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Schedule>>(uri);
        }
    }
}
