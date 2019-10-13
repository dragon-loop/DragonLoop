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
            //set up stop on screen
            if (e.Value == true)
            {
                ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;
                Route route = cell.BindingContext as Route;

                if (route != null)
                {
                    await viewModel.LoadRouteStops(route.RouteId);
                    
                    //Load pins onto map
                    List<Stop> stops = new List<Stop>(viewModel.RouteStops);
                    for(int i = 0; i < viewModel.RouteStops.Count(); i++)
                    {
                        var pin = new Pin()
                        {
                            Position = new Position(Decimal.ToDouble(stops[i].XCoordinate), Decimal.ToDouble(stops[i].YCoordinate)),
                            Label = stops[i].Name
                        };
                        viewModel.Map.Pins.Add(pin);
                    }

                    //TODO: Create a route -> This requires a custom map object:
                    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/map/polyline-map-overlay
                }
            }
            //clear stops on screen
            else
            {
                viewModel.Map.Pins.Clear();
            }
        }

    }
}