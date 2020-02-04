using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using DragonLoopModels;
using System.Linq;
using DragonLoopApp.Views.MapElements;

namespace DragonLoopApp.ViewModels
{
    public class MapViewModel : DragonLoopViewModels.ViewModels.MapViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Route> RoutesCollection { get; set; }

        public Command LoadRoutesCommand { get; set; }

        public CustomMap Map { get; set; }

        public MapViewModel() : base(Settings.UrlBase)
        {
            Title = "Map";
            RoutesCollection = new ObservableCollection<Route>();
            LoadRoutesCommand = new Command(async () => await ExecuteLoadRoutesCommand());
            Map = new CustomMap(
                MapSpan.FromCenterAndRadius(
                    new Position(39.955615, -75.189490), Distance.FromMiles(0.5)))
                        {
                            IsShowingUser = true
                        };
        }

        private async Task ExecuteLoadRoutesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RoutesCollection.Clear();
                await LoadRoutes();
                foreach (var route in Routes)
                {
                    RoutesCollection.Add(route);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ToggleRoute(object sender, ToggledEventArgs e)
        {
            var route = ((sender as Xamarin.Forms.Switch).Parent.Parent as ViewCell).BindingContext as Route;

            if (e.Value)
            {
                await LoadRouteObjects(route);
            }
            else
            {
                RemoveRouteObjects(route);
            }

            RenderMapOverlay();
        }

        private async Task LoadRouteObjects(Route route)
        {
            await LoadStops(route.RouteId);
            await LoadBuses(route.RouteId);
            await LoadRouteSegments(route.RouteId);
        }

        private void RemoveRouteObjects(Route route)
        {
            RemoveStops(route.RouteId);
            RemoveBuses(route.RouteId);
            RemoveRouteSegments(route.RouteId);
        }

        private void RenderMapOverlay()
        {
            Map.Pins.Clear();
            Map.MapElements.Clear();

            foreach (var stop in Stops)
            {
                var pin = new Pin()
                {
                    Position = new Position(decimal.ToDouble(stop.XCoordinate), decimal.ToDouble(stop.YCoordinate)),
                    Label = stop.Name
                };
                Map.Pins.Add(pin);
            }

            foreach (var bus in Buses)
            {
                var pin = new Pin
                {
                    Position = new Position(decimal.ToDouble(bus.XCoordinate), decimal.ToDouble(bus.YCoordinate)),
                    Label = bus.BusId.ToString(),
                    Type = PinType.Generic
                };
                Map.Pins.Add(pin);
            }

            foreach (var routeSegment in RouteSegments)
            {
                var startPosition = new Position(decimal.ToDouble(routeSegment.StartXCoordinate), decimal.ToDouble(routeSegment.StartYCoordinate));
                var nextRouteSegment = RouteSegments.Where(r => r.RouteSegmentId == routeSegment.NextRouteSegmentId).First();
                var endPosition = new Position(decimal.ToDouble(nextRouteSegment.StartXCoordinate), decimal.ToDouble(nextRouteSegment.StartYCoordinate));

                var polyline = new Polyline
                {
                    StrokeWidth = 12,
                    Geopath = {
                        startPosition,
                        endPosition
                    }
                };

                switch (routeSegment.RouteId)
                {
                    case 1:
                        polyline.StrokeColor = Color.Blue;
                        break;
                    case 2:
                        polyline.StrokeColor = Color.Green;
                        break;
                    case 3:
                        polyline.StrokeColor = Color.Red;
                        break;
                }

                Map.MapElements.Add(polyline);
            }
        }
    }
}
