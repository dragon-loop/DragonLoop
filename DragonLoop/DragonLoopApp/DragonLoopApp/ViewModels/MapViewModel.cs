using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DragonLoopModels;
using Xamarin.Forms.Maps;

namespace DragonLoopApp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public ObservableCollection<Route> Routes { get; set; }

        public Command LoadRoutesCommand { get; set; }

        public Map Map { get; set; }

        public MapViewModel()
        {
            Title = "Map";
            Routes = new ObservableCollection<Route>();
            LoadRoutesCommand = new Command(async () => await ExecuteLoadRoutesCommand());
            Map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(39.955615, -75.189490), Distance.FromMiles(0.5)))
                        {
                            IsShowingUser = true
                        };
        }

        async Task ExecuteLoadRoutesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Routes.Clear();
                var routes = await RouteService.GetItemsAsync();
                foreach (var route in routes)
                {
                    Routes.Add(route);
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
    }
}
