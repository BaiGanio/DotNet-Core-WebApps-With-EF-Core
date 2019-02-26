using System;
using System.Collections.Generic;
using System.Text;

namespace Chorap4e.ConsoleClient
{
    class Program
    {
        static readonly List<object> _users = new List<object>();
        static readonly List<object> _socks = new List<object>();
        static readonly Chorap4eDbContext _ctx = new Chorap4eDbContext();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                InitializeUsers();
                PrintCollection(_users);
                InitializeSocks();
                PrintCollection(_socks);

                _ctx.Database.EnsureCreated();
                AddCollectionToDb(_users);
                AddCollectionToDb(_socks);


                Console.WriteLine();
                Console.WriteLine("----- Job well done! -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        

        #region PrivateMethods

        private static void InitializeUsers()
        {
            Console.WriteLine("Starting User initialization!");

            var me = new User("Lyuben", "fakeP@ss");
            var other = new User("Lyuben-Other", "P@ssfake");
            var other2 = new User("Lyuben-Other2", "P@ssfake2");
            _users.AddRange(new List<User>() { me, other, other2 });

            Console.WriteLine("DONE with User initialization!");
        }

        private static void InitializeSocks()
        {
            Console.WriteLine("Starting Socks initialization!");
            Sock woolenSock = new Sock(10.99, Color.Pink, Size.L, Material.Woolean);
            Sock stinkySock = new Sock(19.99, Color.Mixed, Size.L, Material.Stincky);
            _socks.AddRange(new List<object>() { woolenSock, stinkySock });
            Console.WriteLine("DONE with Socks initialization!");
        }

        private static void PrintCollection(List<object> collection)
        {
            Console.WriteLine($"Printing collection:");
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"DONE with printing collection!");
            Console.WriteLine(new string('-', 20));
        }

        private static void AddCollectionToDb(List<object> collection)
        {
            foreach (var item in collection)
            {
                if (item is User user) _ctx.Users.Add(user);
                else if (item is Sock sock) _ctx.Socks.Add(sock);
            }
            _ctx.SaveChanges();
        }

        #endregion

    }
}
