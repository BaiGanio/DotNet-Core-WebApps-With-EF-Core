using System.Data.Entity;
using AthManager.Model;

namespace AuthManager.DB
{
    public class AuthManagerDbContext : DbContext
    {
        public AuthManagerDbContext()
            : base("name=AuthManagerConnection")
        { }

        public IDbSet<User> Users { get; set; }
        public IDbSet<AppConsumer> AppConsumers { get; set; }
    }
}
