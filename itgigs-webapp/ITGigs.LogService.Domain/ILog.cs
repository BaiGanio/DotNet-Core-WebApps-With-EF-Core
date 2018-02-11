using ITGigs.Common.Extensions;
using System;
using System.Threading.Tasks;

namespace ITGigs.LogService.Domain
{
    public interface ILog
    {
        Task LogCustomExceptionAsync(Exception ex, CustomId id);
        Task LogSendedEmailAsync();
        Task LogPerformerRequestAsync();
        Task LogVenueOwnerRequestAsync();
    }
}
