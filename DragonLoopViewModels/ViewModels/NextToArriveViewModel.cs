
using DragonLoopModels;
using DragonLoopViewModels.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class NextToArriveViewModel
    {
        private RouteService RouteService;

        private StopService StopService;

        public IEnumerable<Route> Routes { get; set; }

        public IEnumerable<Stop> Stops { get; set; }

        public Bus NextBus { get; set; }

        public TimeSpan NextExpectedTime { get; set; }

        public NextToArriveViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
            StopService = new StopService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task LoadStops(int id)
            => Stops = await RouteService.GetStopsAsync(id);

        public async Task GetNextBusToArrive(int id)
        {
            NextBus = await StopService.GetNextBusAsync(id);
            NextExpectedTime = await StopService.GetNextExpectedTimeAsync(id, DateTime.Now.TimeOfDay);
        }
    }
}
