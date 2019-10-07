using DragonLoopApp.ViewModels;
<<<<<<< HEAD
using System.Linq;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonLoopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulesPage : ContentPage
    {
        SchedulesViewModel viewModel;

        public SchedulesPage()
        {
            InitializeComponent();

<<<<<<< HEAD
            BindingContext = viewModel = new SchedulesViewModel(SchedulesGrid);
=======
            BindingContext = viewModel = new SchedulesViewModel();
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

<<<<<<< HEAD
            if (viewModel.Schedules == null || !viewModel.Schedules.Any())
=======
            if (viewModel.Schedules == null || !viewModel.Schedules.Any())                
>>>>>>> b9d7ac25d64d471a36289b1f854981c1977fda5e
                viewModel.LoadSchedulesCommand.Execute(null);
        }
    }
}