using DragonLoopModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragonLoopApp.ViewModels
{
    public class NotificationsViewModel : DragonLoopViewModels.ViewModels.NotificationsViewModel
    {
        public string Title { get; set; }

        private bool IsBusy { get; set; }

        public ObservableCollection<Notification> NotificationsCollection { get; set; }

        public Command LoadNotificationsCommand { get; set; }

        public NotificationsViewModel() : base(Settings.UrlBase)
        {
            Title = "Notifications";
            NotificationsCollection = new ObservableCollection<Notification>();
            LoadNotificationsCommand = new Command(async () => await ExecuteLoadNotificationsCommand());
        }

        private async Task ExecuteLoadNotificationsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            NotificationsCollection.Clear();
            await LoadNotifications();
            foreach (var notification in Notifications.OrderByDescending(n => n.NotificationDateTime))
            {
                NotificationsCollection.Add(notification);
            }

            IsBusy = false;
        }
    }
}
