using AuthManager452.Models;
using System.Data.Entity;

namespace AuthManager452.DB
{
    public class AuthManager452DbContext : DbContext
    {
        public AuthManager452DbContext()
            : base("name=AuthManager452Connection")
        { }

        public DbSet<FunkyUser> FunkyUsers { get; set; }
    }
}
