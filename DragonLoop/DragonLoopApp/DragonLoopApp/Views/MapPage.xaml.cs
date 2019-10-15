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
                viewModel.LoadRoutesCommand.Execute(null);
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
                    
                    //Load pins onto map
                    foreach(var stop in viewModel.RouteStops)
                    {
                        var pin = new Pin()
                        {
                            Position = new Position(Decimal.ToDouble(stop.XCoordinate), Decimal.ToDouble(stop.YCoordinate)),
                            Label = stop.Name,
                            Address = stop.RouteId.ToString()
                        };
                        viewModel.Map.Pins.Add(pin);
                    }
                    List<Stop> stops = new List<Stop>(viewModel.RouteStops);

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

                    List<Pin> stopsRemove = viewModel.Map.Pins.Where(s => s.Address == route.RouteId.ToString()).ToList();

                    if (stopsRemove.Count > 0)
                    {
                        foreach(var pin in stopsRemove)
                        {
                            viewModel.Map.Pins.Remove(pin);
                        }
                    }
                }
            }
        }

    }
}