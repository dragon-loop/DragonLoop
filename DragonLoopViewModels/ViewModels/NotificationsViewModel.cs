using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class NotificationsViewModel
    {
        private readonly NotificationService NotificationService;

        public IEnumerable<Notification> Notifications { get; set; }

        public NotificationsViewModel(string urlBase)
        {
            NotificationService = new NotificationService(urlBase);
        }

        public async Task LoadNotifications()
            => Notifications = await NotificationService.GetNotificationsAsync();
    }
}
