using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthManager2
{
    public class AuthManagerDBContext : DbContext
    {
        public AuthManagerDBContext()
            :base("name=AuthManager")
        {

        }

    //    public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
