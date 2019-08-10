using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

using DragonLoopModels;

namespace DragonLoopApp.ViewModels
{
    public class MapViewModel : DragonLoopViewModels.ViewModels.MapViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Route> RoutesCollection { get; set; }

        public Command LoadRoutesCommand { get; set; }

        public Map Map { get; set; }

        public MapViewModel() : base(Settings.UrlBase)
        {
            Title = "Map";
            RoutesCollection = new ObservableCollection<Route>();
            LoadRoutesCommand = new Command(async () => await ExecuteLoadRoutesCommand());
            Map = new Map(
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
    }
}
