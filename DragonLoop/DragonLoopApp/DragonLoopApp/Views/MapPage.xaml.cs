using DragonLoopApp.ViewModels;
using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace DragonLoopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        MapViewModel viewModel;

        public MapPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MapViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Routes == null || !viewModel.Routes.Any())
                viewModel.LoadDataCommand.Execute(null);
        }

        private async void Handle_Route_Toggle(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;
            Route route = cell.BindingContext as Route;

            //set up stop on screen
            if (e.Value)
            {

                if (route != null)
                {
                    await viewModel.LoadRouteStops(route.RouteId);
                    await viewModel.LoadBuses();

                    //Load pins onto map
                    foreach(var stop in viewModel.RouteStops)
                    {
                        var pin = new CustomPin()
                        {
                            Position = new Position(Decimal.ToDouble(stop.XCoordinate), Decimal.ToDouble(stop.YCoordinate)),
                            Label = stop.Name,
                            RouteId = stop.RouteId,
                            Type = PinType.Place
                        };
                        viewModel.Map.Pins.Add(pin);
                        viewModel.Map.CustomPins.Add(pin);
                    }

                    List<Bus> selectedRouteBus = viewModel.Buses.Where(b => b.RouteId == route.RouteId).ToList();

                    foreach(var bus in selectedRouteBus)
                    {
                        var pin = new CustomPin
                        {
                            Position = new Position(Decimal.ToDouble(bus.XCoordinate), Decimal.ToDouble(bus.YCoordinate)),
                            Label = bus.BusId.ToString(),
                            Type = PinType.Generic,
                            RouteId = bus.RouteId
                        };
                        viewModel.Map.Pins.Add(pin);
                        viewModel.Map.CustomPins.Add(pin);

                    }

                    //TODO: Create a route -> This requires a custom map object:
                    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/map/polyline-map-overlay
                }
            }
            //clear stops on screen
            else
            {
                //Remove pins from stuff disabled
                if(route != null)
                {
                    await viewModel.LoadRouteStops(route.RouteId);

                    List<CustomPin> stopsRemove = viewModel.Map.CustomPins.Where(s => s.RouteId == route.RouteId).ToList();

                    if (stopsRemove.Count > 0)
                    {
                        foreach(var pin in stopsRemove)
                        {
                            viewModel.Map.CustomPins.Remove(pin);
                            viewModel.Map.Pins.Remove(pin);
                        }
                    }
                }
            }
        }

    }
}