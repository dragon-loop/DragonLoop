using DragonLoopApp.ViewModels;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragonLoopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        NotificationsViewModel viewModel;

        public NotificationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NotificationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Notifications == null || !viewModel.Notifications.Any())
                viewModel.LoadNotificationsCommand.Execute(null);
        }
    }
}