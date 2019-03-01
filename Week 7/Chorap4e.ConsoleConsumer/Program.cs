using Chorap4e.Common;
using Chorap4e.DbContex;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chorap4e.ConsoleConsumer
{
    class Program
    {
        private static Chorap4eDbContext ctx = new Chorap4eDbContext();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello World!");
            bool isAdmin = false;

            isAdmin = AuthorizeUser(isAdmin);

            Thread.Sleep(1500);
            Console.WriteLine("Doing something and coming for some other data!");


            var user = ctx.Users.FirstOrDefault(u => u.IsLogged == true);
            Console.WriteLine(user.ToString());

            if (user != null)
            {
                //Print something else
            }
            else
            {
                Console.WriteLine("Bye ye!");
            }


        }

        private static bool AuthorizeUser(bool isAdmin)
        {
            Console.Write("Enter password:");
            string plainPass = Console.ReadLine();
            string passHash = HashUtils.HashPassword(plainPass);

            var users = ctx.Users.ToList();

            foreach (var item in users)
            {
                if (item.Password != passHash) continue;

                isAdmin = true;
                Console.WriteLine($"Hello, admin {item.Name}");
                PrintSocks();

                item.IsLogged = true;
                ctx.Users.Update(item);
                ctx.SaveChanges();
            }

            if (isAdmin == false)
            {
                Console.WriteLine("You are not authirze!");
            }

            return isAdmin;
        }

        private static void PrintSocks()
        {
            var socks = ctx.Socks.ToList();
            foreach (var item in socks)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
