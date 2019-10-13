using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class MapViewModel
    {
        public IEnumerable<Route> Routes { get; set; }

        private RouteService RouteService;

        private StopService StopService;

        public IEnumerable<Stop> RouteStops { get; set; }

        public MapViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
            StopService = new StopService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task LoadRouteStops(int id) => RouteStops = await StopService.GetStopsAsync(id);
    }
}
