using ITGigs.DB.Heplers.InMemoryObjects;
using Microsoft.EntityFrameworkCore;

namespace ITGigs.DB.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            InitialUsers.Seed(context);
            InitialVenues.Seed(context);
            InitialITGigs.Seed(context);
        }
    }
}
