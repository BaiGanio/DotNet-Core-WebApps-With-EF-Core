using System;
using System.Runtime.InteropServices;
using System.Text;
using Project.DB;
using Project.Models;

namespace Project.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            var ctx = new ProjectContext();
            ctx.Database.Initialize(true);

            Console.OutputEncoding = Encoding.UTF8;
            User peshko = new User("Peshko", "123", false);
            User lyuben =new User("Любен", "123", false);
            User bugsy = new User("Bugs Bunny", "123", true);
            //Console.WriteLine("----------------------------");
            //Console.WriteLine(peshko);
            //Console.WriteLine(lyuben);


            ctx.Users.Add(peshko);
            ctx.Users.Add(lyuben);
            ctx.Users.Add(bugsy);

            ctx.SaveChanges();


            Console.WriteLine("Databese ON!");

        }
    }
}
