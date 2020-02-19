using DragonLoopApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonLoopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextToArrive : ContentPage
    {
        NextToArriveViewModel viewModel;

        public NextToArrive()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new NextToArriveViewModel(NextToArriveLabel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Routes == null || !viewModel.Routes.Any())
                viewModel.LoadRoutesCommand.Execute(null);
        }

        private async void SelectRouteIndexChanged(object sender, EventArgs e)
            => await viewModel.SelectRouteIndexChanged(sender, e);

        private async void SelectStopIndexChanged(object sender, EventArgs e)
            => await viewModel.SelectStopIndexChanged(sender, e);
    }
}