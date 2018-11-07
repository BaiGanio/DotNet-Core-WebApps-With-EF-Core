using ITGigs.UserService.Domain.Models;
using System.Threading.Tasks;

namespace ITGigs.NotificationService.Domain
{
    public interface INotificationActor
    {
        Task SendConfirmationEmailAsync(User user);
        Task SendPerformerRequestEmailAsync(User user);
        Task SendVenueOwnerRequestEmailAsync(User user);
        Task SendChangePasswordEmailAsync(User user);
    }
}
