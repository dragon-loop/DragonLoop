using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragonLoopApp.ViewModels
{
    public class SchedulesViewModel : DragonLoopViewModels.ViewModels.ScheduleViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public Grid SchedulesGrid { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public SchedulesViewModel(Grid schedulesGrid) : base(Settings.UrlBase)
        {
            Title = "Schedules";
            SchedulesGrid = schedulesGrid;
            LoadSchedulesCommand = new Command(async () => await ExecuteLoadSchedulesCommand());
        }

        private async Task ExecuteLoadSchedulesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await LoadRoutes();
                await SetSelectedRoute(Routes.First());
                await LoadSchedule();

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
