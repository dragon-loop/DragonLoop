using DragonLoopApp.ViewModels;
using System.Linq;
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

            BindingContext = viewModel = new SchedulesViewModel(SelectRoute, SchedulesGrid);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Schedules == null || !viewModel.Schedules.Any())
                viewModel.LoadSchedulesCommand.Execute(null);
        }
    }
}