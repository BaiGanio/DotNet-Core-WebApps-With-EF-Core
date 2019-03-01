using Chorap4e.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chorap4e.DbContex
{
    public sealed class Chorap4eDbContext : DbContext
    {
        //readonly string dbconn = "Server=.;Database=ch4orap4e-local-db;Trusted_Connection=True;";
        readonly string dbconn = "Server=(localdb)\\mssqllocaldb;Database=ch4orap4e-local-db;Trusted_Connection=True;";        
        public DbSet<Sock> Socks { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(c => c.Socks)
        //        .WithOne(e => e.User)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbconn);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
