using ITGigs.UserService.Domain.Models;
using System.Threading.Tasks;

namespace ITGigs.NotificationService.Domain
{
    public interface INotificationActor
    {
        Task SendConfirmationEmailAsync(User user);
        Task SendChangePasswordEmailAsync(User user);
    }
}
