using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DragonLoopModels;

namespace DragonLoopApp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public ObservableCollection<Route> Routes { get; set; }

        public Command LoadRoutesCommand { get; set; }

        public MapViewModel()
        {
            Title = "Map";
            Routes = new ObservableCollection<Route>();
            LoadRoutesCommand = new Command(async () => await ExecuteLoadRoutesCommand());
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
