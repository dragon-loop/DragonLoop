using DragonLoopApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonLoopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulesPage : ContentPage
    {
        readonly SchedulesViewModel viewModel;

        public SchedulesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SchedulesViewModel(SchedulesGrid);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Schedules == null || !viewModel.Schedules.Any())
                viewModel.LoadSchedulesCommand.Execute(null);
        }

        private async void SelectRouteIndexChanged(object sender, EventArgs e)
            => await viewModel.SelectRouteIndexChanged(sender, e);
    }
}