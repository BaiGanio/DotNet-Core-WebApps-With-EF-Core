using System;
using System.Threading.Tasks;

namespace ITGigs.LogService.Domain
{
    public interface ILogger
    {
        Task LogExceptionAsync(Exception ex);
        Task LogSendedEmailAsync();
        Task LogPerformerRequestAsync();
        Task LogVenueOwnerRequestAsync();
    }
}
