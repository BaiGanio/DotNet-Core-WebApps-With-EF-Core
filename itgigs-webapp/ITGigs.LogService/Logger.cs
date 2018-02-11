using ITGigs.Common.Extensions;
using ITGigs.DB;
using ITGigs.LogService.Domain;
using ITGigs.LogService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ITGigs.LogService
{
    public sealed class Logger : ILog
    {
        #region Private fields

        private AppDbContext _ctx = new AppDbContext();

        #endregion

        /*Lazy objects are thread safe*/
        private static readonly Lazy<Logger> instance =
            new Lazy<Logger>(() => new Logger());

        public static Logger GetInstance
        {
            get { return instance.Value; }
        }

        public async Task LogCustomExceptionAsync(Exception ex,CustomId id = null)
        {
            CustomException exception = new CustomException(ex, id);
            _ctx.CustomExceptions.Add(exception);
            await _ctx.SaveChangesAsync();
        }

        public Task LogSendedEmailAsync()
        {
            throw new NotImplementedException();
        }

        public Task LogPerformerRequestAsync()
        {
            throw new NotImplementedException();
        }

        public Task LogVenueOwnerRequestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
