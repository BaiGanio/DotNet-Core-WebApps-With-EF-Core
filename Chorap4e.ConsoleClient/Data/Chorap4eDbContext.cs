using Microsoft.EntityFrameworkCore;

namespace Chorap4e.ConsoleClient
{
    public sealed class Chorap4eDbContext : DbContext
    {
        readonly string dbconn = "Server=.;Database=ch4orap4e-local-db;Trusted_Connection=True;";

        public DbSet<Sock> Socks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbconn);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
