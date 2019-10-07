<<<<<<< HEAD
﻿using System;
=======
﻿using DragonLoopModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
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

<<<<<<< HEAD
        public Grid SchedulesGrid { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public SchedulesViewModel(Grid schedulesGrid) : base(Settings.UrlBase)
        {
            Title = "Schedules";
            SchedulesGrid = schedulesGrid;
=======
        public ObservableCollection<ListView> TripsCollection { get; set; }

        public Command LoadSchedulesCommand { get; set; }

        public SchedulesViewModel() : base(Settings.UrlBase)
        {
            Title = "Schedules";
            TripsCollection = new ObservableCollection<ListView>();
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
            LoadSchedulesCommand = new Command(async () => await ExecuteLoadSchedulesCommand());
        }

        private async Task ExecuteLoadSchedulesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
<<<<<<< HEAD
=======
                TripsCollection.Clear();
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
                await LoadRoutes();
                await SetSelectedRoute(Routes.First());
                await LoadSchedule();

<<<<<<< HEAD
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
=======
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
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
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
