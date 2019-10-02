using DragonLoopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            BindingContext = viewModel = new SchedulesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Schedules == null || !viewModel.Schedules.Any())                
                viewModel.LoadSchedulesCommand.Execute(null);
        }
    }
}