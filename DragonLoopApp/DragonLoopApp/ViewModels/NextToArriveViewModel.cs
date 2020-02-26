using DragonLoopModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragonLoopApp.ViewModels
{
    public class NextToArriveViewModel : DragonLoopViewModels.ViewModels.NextToArriveViewModel, INotifyPropertyChanged
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Route> RoutesCollection { get; set; }

        public ObservableCollection<Stop> StopsCollection { get; set; }

        public Command LoadRoutesCommand { get; set; }

        public Label NextToArriveLabel { get; set; }

        public NextToArriveViewModel(Label nextToArriveLabel) : base(Settings.UrlBase)
        {
            Title = "Next To Arrive";
            NextToArriveLabel = nextToArriveLabel;
            RoutesCollection = new ObservableCollection<Route>();
            StopsCollection = new ObservableCollection<Stop>();
            LoadRoutesCommand = new Command(async () => await ExecuteLoadRoutesCommand());
        }

        private async Task ExecuteLoadRoutesCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            RoutesCollection.Clear();
            await LoadRoutes();
            foreach (var route in Routes)
            {
                RoutesCollection.Add(route);
            }

            IsBusy = false;
        }

        public async Task SelectRouteIndexChanged(object sender, EventArgs e)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            var route = (sender as Picker).SelectedItem as Route;
            StopsCollection.Clear();
            await SetSelectedRoute(route);
            foreach (var stop in Stops)
            {
                StopsCollection.Add(stop);
            }

            IsBusy = false;
        }

        public async Task SelectStopIndexChanged(object sender, EventArgs e)
        {
            if (IsBusy)
                return;
            IsBusy = true;

            var stop = (sender as Picker).SelectedItem as Stop;
            await SetSelectedStop(stop);

            if (NextBusLateness < 0)
            {
                NextToArriveLabel.TextColor = Color.Green;
                NextToArriveLabel.Text = $"<b>Scheduled Arrival: {NextExpectedTime}</b><br />" +
                                         $"{Math.Abs(NextBusLateness)}m early - Bus #{NextBus.BusId}";
            }
            else if (NextBusLateness > 0)
            {
                NextToArriveLabel.TextColor = Color.Red;
                NextToArriveLabel.Text = $"<b>Scheduled Arrival: {NextExpectedTime}</b><br />" +
                                         $"{NextBusLateness}m late - Bus #{NextBus.BusId}";
            }
            else
            {
                NextToArriveLabel.TextColor = Color.Green;
                NextToArriveLabel.Text = $"<b>Scheduled Arrival: {NextExpectedTime}</b><br />" +
                                         $"On Time - Bus #{NextBus.BusId}";
            }
            

            IsBusy = false;
        }

        
    }
}
