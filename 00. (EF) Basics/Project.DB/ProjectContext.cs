using System.Data.Entity;
using Project.Models;

namespace Project.DB
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("name = ProjectContext")
        {
            
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Student> Students { get; set; }
    }
}
