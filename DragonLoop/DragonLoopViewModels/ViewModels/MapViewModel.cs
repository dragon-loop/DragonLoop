using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class MapViewModel
    {
        private RouteService RouteService;

        public IEnumerable<Route> Routes { get; set; }

        public IEnumerable<Bus> Buses { get; set; }

        public IEnumerable<Stop> Stops { get; set; }       

        public MapViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task LoadBuses(int id)
        {
            var buses = await RouteService.GetBusesAsync(id);
            Buses = (Buses == null) ? buses : Buses.Concat(buses);
        }

        public void RemoveBuses(int id)
            => Buses = GetBusesExcept(id).ToList();

        private IEnumerable<Bus> GetBusesExcept(int id)
        {
            foreach (Bus bus in Buses)
            {
                if (bus.RouteId != id)
                {
                    yield return bus;
                }
            }
        }

        public async Task LoadStops(int id)
        {
            var stops = await RouteService.GetStopsAsync(id);
            Stops = (Stops == null) ? stops : Stops.Concat(stops);
        }

        public void RemoveStops(int id)
            => Stops = GetStopsExcept(id).ToList();

        private IEnumerable<Stop> GetStopsExcept(int id)
        {
            foreach (Stop stop in Stops)
            {
                if (stop.RouteId != id)
                {
                    yield return stop;
                }
            }
        }
    }
}
