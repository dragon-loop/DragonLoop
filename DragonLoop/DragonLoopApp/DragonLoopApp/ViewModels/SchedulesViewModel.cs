using DragonLoopModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public ObservableCollection<ListView> TripsCollection { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public SchedulesViewModel() : base(Settings.UrlBase)
        {
            Title = "Schedules";
            TripsCollection = new ObservableCollection<ListView>();
            LoadSchedulesCommand = new Command(async () => await ExecuteLoadSchedulesCommand());
        }

        private async Task ExecuteLoadSchedulesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                TripsCollection.Clear();
                await LoadRoutes();
                await SetSelectedRoute(Routes.First());
                await LoadSchedule();

                foreach (var trip in Schedules)
                {
                    var schedulesCollection = new ObservableCollection<Schedule>();                    
                    foreach (var schedule in trip)
                    {
                        schedulesCollection.Add(schedule);

                        var label = new Label();
                    }

                    var listView = new ListView
                    {
                        ItemsSource = schedulesCollection,
                        ItemTemplate = new DataTemplate(() =>
                        {
                            return new ViewCell
                            {
                                View = new Label()
                            };
                        })
                    };
                    TripsCollection.Add(listView);
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
