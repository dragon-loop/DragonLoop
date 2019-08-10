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
    public partial class MapPage : ContentPage
    {
        MapViewModel viewModel;

        public MapPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MapViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Routes == null || !viewModel.Routes.Any())
                viewModel.LoadRoutesCommand.Execute(null);
        }
    }
}