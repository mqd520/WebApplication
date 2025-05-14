
using MediatR;

using WebApplication69.Notifications;

namespace WebApplication69.NotificationHandlers
{
    public class MyNotificationHandler : INotificationHandler<MyNotification>
    {
        public Task Handle(MyNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notification received: {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
