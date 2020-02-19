
using DragonLoopModels;
using DragonLoopViewModels.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class NextToArriveViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private RouteService RouteService;

        private StopService StopService;

        public IEnumerable<Route> Routes { get; set; }

        public IEnumerable<Stop> Stops { get; set; }

        private Route selectedRoute;
        public Route SelectedRoute
        {
            get { return selectedRoute; }
            private set
            {
                selectedRoute = value;
                OnPropertyChanged();
            }
        }

        private Stop selectedStop;
        public Stop SelectedStop
        {
            get { return selectedStop; }
            private set
            {
                selectedStop = value;
                OnPropertyChanged();
            }
        }

        public Bus NextBus { get; set; }

        public TimeSpan NextBusLateness { get; set; }

        public TimeSpan NextExpectedTime { get; set; }

        public NextToArriveViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
            StopService = new StopService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();

        public async Task SetSelectedRoute(Route route)
        {
            SelectedRoute = route;
            Stops = await RouteService.GetStopsAsync(SelectedRoute.RouteId);
        }

        public async Task SetSelectedStop(Stop stop)
        {
            SelectedStop = stop;
            NextBus = await StopService.GetNextBusAsync(stop.StopId);

            var expectedTime = await StopService.GetExpectedTimeAsync(NextBus.LastStopId.Value, NextBus.TripId);
            NextBusLateness = expectedTime - NextBus.LastStopTime.Value;

            NextExpectedTime = await StopService.GetNextExpectedTimeAsync(stop.StopId, DateTime.Now.TimeOfDay);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
