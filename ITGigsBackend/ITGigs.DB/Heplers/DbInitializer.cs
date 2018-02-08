using ITGigs.DB.Heplers.InMemoryObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITGigs.DB.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            InitialUsers.Seed(context);
            if (!context.Venues.Any()) SeedVenues(context);
            InitialITGigs.Seed(context);
        }

        #region PrivateMethods

        private static void SeedVenues(AppDbContext context)
        {
            foreach (var initalVenue in Constants.GetInitialVenues())
            {
                context.Venues.Add(initalVenue);
            }
            context.SaveChanges();
        }

        #endregion

    }
}
