using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<IGrouping<int, Schedule>> Schedules { get; set; }

        public IEnumerable<Route> Routes { get; set; }

        public Route SelectedRoute { get; set; }

        private ScheduleService ScheduleService;

        private RouteService RouteService;

        private StopService StopService;

        public ScheduleViewModel(string urlBase)
        {
            ScheduleService = new ScheduleService(urlBase);
            RouteService = new RouteService(urlBase);
            StopService = new StopService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task LoadSchedule()
        {
            var schedules = await ScheduleService.GetSchedulesAsync(SelectedRoute.RouteId);
            Schedules = schedules.GroupBy(s => s.TripId);
        }

        public async Task SetSelectedRoute(Route route)
        {
            SelectedRoute = route;
            var stops = await StopService.GetStopsAsync(SelectedRoute.RouteId);
            SelectedRoute.Stops = stops.ToList();
        }
    }
}
