using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class ScheduleViewModel
    {
        private RouteService RouteService;

        public IEnumerable<IGrouping<int, Schedule>> Schedules { get; set; }

        public IEnumerable<Route> Routes { get; set; }

        public Route SelectedRoute { get; private set; }

        public ScheduleViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task SetSelectedRoute(Route route)
        {
            SelectedRoute = route;

            var stops = await RouteService.GetStopsAsync(SelectedRoute.RouteId);
            SelectedRoute.Stops = stops.ToList();

            var schedules = await RouteService.GetSchedulesAsync(SelectedRoute.RouteId);
            Schedules = schedules.OrderBy(s => s.ExpectedTime).GroupBy(s => s.TripId);
        }       
    }
}
