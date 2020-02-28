using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public class NotificationService
    {
        private const string UrlPath = "/api/notification";
        private readonly string UrlBase;

        public NotificationService(string urlBase)
            => UrlBase = urlBase;

        public async Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = UrlPath;
            var uri = builder.ToString();

            return await RequestProvider.GetAsync<IEnumerable<Notification>>(uri); ;
        }

        public async Task PutNotificationAsync(Notification notification)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{notification.NotificationId}";
            var uri = builder.ToString();

            await RequestProvider.PutAsync(uri, notification);
        }

        public async Task<Notification> PostNotificationAsync(string message)
        {
            var notification = new Notification
            {
                Message = message,
                NotificationDateTime = DateTime.Now
            };

            var builder = new UriBuilder(UrlBase);
            builder.Path = UrlPath;
            var uri = builder.ToString();

            return await RequestProvider.PostAsync(uri, notification);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var builder = new UriBuilder(UrlBase);
            builder.Path = $"{UrlPath}/{id}";
            var uri = builder.ToString();

            await RequestProvider.DeleteAsync(uri);
        }
    }
}
