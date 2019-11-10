using System;
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

        public Picker SelectRoute { get; set; }

        public Grid SchedulesGrid { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public Route GetSelectedRoute()
        {
            var routes = Routes.Where(r => r.Name == SelectRoute.SelectedItem.ToString());
            return routes.First();
        }

        public SchedulesViewModel(Picker selectRoute, Grid schedulesGrid) : base(Settings.UrlBase)
        {
            Title = "Schedules";
            SchedulesGrid = schedulesGrid;
            SelectRoute = selectRoute;
            LoadSchedulesCommand = new Command(async () => await ExecuteLoadSchedulesCommandAsync());
        }

        private async Task ExecuteLoadSchedulesCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SchedulesGrid.Children.Clear();
                SchedulesGrid.RowDefinitions.Clear();
                SchedulesGrid.ColumnDefinitions.Clear();
                SchedulesGrid.RowDefinitions.Add(new RowDefinition());

                await LoadRoutes();
                await SetSelectedRoute(Routes.First());
                await LoadSchedule();

                foreach (var route in Routes)
                {
                    SelectRoute.Items.Add(route.Name);
                }

                SelectRoute.SelectedIndexChanged += async (sender, args) =>
                {
                    SchedulesGrid.Children.Clear();
                    SchedulesGrid.RowDefinitions.Clear();
                    SchedulesGrid.ColumnDefinitions.Clear();

                    if (SelectRoute.SelectedIndex != -1)
                    {
                        int col = 0;
                        await SetSelectedRoute(GetSelectedRoute());
                        await LoadSchedule();
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

                        int row = 1;
                        foreach (var schedules in Schedules)
                        {
                            SchedulesGrid.RowDefinitions.Add(new RowDefinition());
                            col = 0;
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
                };
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