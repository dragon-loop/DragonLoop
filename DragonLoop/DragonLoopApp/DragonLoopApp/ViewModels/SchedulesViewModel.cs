using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DragonLoopModels;
using Xamarin.Forms;

namespace DragonLoopApp.ViewModels
{
    public class SchedulesViewModel : DragonLoopViewModels.ViewModels.ScheduleViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Route> RoutesCollection { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public Grid SchedulesGrid { get; set; }

        public SchedulesViewModel(Grid schedulesGrid) : base(Settings.UrlBase)
        {
            Title = "Schedules";
            RoutesCollection = new ObservableCollection<Route>();
            LoadSchedulesCommand = new Command(async () => await ExecuteLoadSchedulesCommand());
            SchedulesGrid = schedulesGrid;            
        }

        private async Task ExecuteLoadSchedulesCommand()
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

                await SetSelectedRoute(Routes.First());

                RenderSchedulesGrid();
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

        public async Task SelectRouteIndexChanged(object sender, EventArgs e)
        {
            var route = (sender as Picker).SelectedItem as Route;
            await SetSelectedRoute(route);

            RenderSchedulesGrid();
        }



        private void RenderSchedulesGrid()
        {
            ClearGrid();
            PopulateStops();
            PopulateSchedule();
        }

        private void ClearGrid()
        {
            SchedulesGrid.Children.Clear();
            SchedulesGrid.RowDefinitions.Clear();
            SchedulesGrid.ColumnDefinitions.Clear();
        }

        private void PopulateStops()
        {
            SchedulesGrid.RowDefinitions.Add(new RowDefinition());
            int col = 0;
            foreach (var stop in SelectedRoute.Stops)
            {
                SchedulesGrid.ColumnDefinitions.Add(new ColumnDefinition());
                var label = new Label
                {
                    Text = stop.Name,
                    FontAttributes = FontAttributes.Bold
                };
                SchedulesGrid.Children.Add(label, col, 0);
                col++;
            }
        }

        private void PopulateSchedule()
        {
            int row = 1;
            foreach (var schedules in Schedules)
            {
                SchedulesGrid.RowDefinitions.Add(new RowDefinition());
                int col = 0;
                foreach (var schedule in schedules)
                {
                    var label = new Label
                    {
                        Text = schedule.ExpectedTime.ToString("hh\\:mm")
                    };
                    SchedulesGrid.Children.Add(label, col, row);
                    col++;
                }
                row++;
            }
        }
    }
}