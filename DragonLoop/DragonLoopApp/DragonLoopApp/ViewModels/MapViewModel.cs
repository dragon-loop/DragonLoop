using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using DragonLoopModels;
using DragonLoopApp.Views;

namespace DragonLoopApp.ViewModels
{
    public class MapViewModel : DragonLoopViewModels.ViewModels.MapViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Route> RoutesCollection { get; set; }
        
        public ObservableCollection<Bus> BusCollection { get; set; }

        public Command LoadDataCommand { get; set; }

        public CustomMap Map { get; set; }

        public MapViewModel() : base(Settings.UrlBase)
        {
            Title = "Map";
            RoutesCollection = new ObservableCollection<Route>();
            BusCollection = new ObservableCollection<Bus>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());
            Map = new CustomMap(
                MapSpan.FromCenterAndRadius(
                    new Position(39.955615, -75.189490), Distance.FromMiles(0.5)))
                        {
                            IsShowingUser = true
                        };
        }

        private async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await ExecuteLoadRoutes();
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
        private async Task ExecuteLoadRoutes()
        {
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
        }
    }
}
