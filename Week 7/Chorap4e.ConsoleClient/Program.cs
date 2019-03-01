using Chorap4e.Common;
using Chorap4e.DbContex;
using Chorap4e.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Chorap4e.ConsoleClient
{
    class Program
    {
        static readonly List<User> _users = new List<User> ();
        static readonly List<Sock> _socks = new List<Sock>();
        static readonly Chorap4eDbContext _ctx = new Chorap4eDbContext();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                InitializeSocks();
                PrintCollection(_socks);
                InitializeUsers();
               PrintCollection(_users);             

                _ctx.Database.EnsureCreated();
                AddCollectionToDb(_socks);
                AddCollectionToDb(_users);

                Console.WriteLine();
                Console.WriteLine("----- Job well done! -----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintCollection(List<User> users)
        {
            Console.WriteLine($"Printing collection:");
            Console.WriteLine();
            Thread.Sleep(1500);
            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
                Thread.Sleep(500);
            }
            Console.WriteLine();
            Thread.Sleep(1500);
            Console.WriteLine($"DONE with printing collection!");
            Console.WriteLine(new string('-', 20));
        }

        private static void PrintCollection(List<Sock> socks)
        {
            Console.WriteLine($"Printing collection:");
            Console.WriteLine();
            Thread.Sleep(1500);
            foreach (var item in socks)
            {
                Console.WriteLine(item.ToString());
                Thread.Sleep(500);
            }
            Console.WriteLine();
            Thread.Sleep(1500);
            Console.WriteLine($"DONE with printing collection!");
            Console.WriteLine(new string('-', 20));
        }

        #region PrivateMethods

        private static void InitializeUsers()
        {            
            Console.WriteLine("Starting User initialization!");
            Thread.Sleep(1500);
            var me = new User("Lyuben", HashUtils.HashPassword("fakeP@ss"));
            var other = new User("Lyuben-Other", "P@ssfake");
            var other2 = new User("Lyuben-Other2", "P@ssfake2");
            _users.AddRange(new List<User>() { me, other, other2 });
            Console.WriteLine("DONE with User initialization!");
           Thread.Sleep(1500);
        }

        private static void InitializeSocks()
        {
            Console.WriteLine("Starting Socks initialization!");
            Thread.Sleep(1500);
            Sock woolenSock = new Sock(10.99, Color.Pink, Size.L, Material.Woolean);
            Sock stinkySock = new Sock(19.99, Color.Mixed, Size.L, Material.Stinky);
            _socks.AddRange(new List<Sock>() { woolenSock, stinkySock });
            Console.WriteLine("DONE with Socks initialization!");
            Thread.Sleep(1500);
        }

        private static void PrintCollection(List<object> collection)
        {
            Console.WriteLine($"Printing collection:");
            Console.WriteLine();
            Thread.Sleep(1500);
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
                Thread.Sleep(500);
            }
            Console.WriteLine();
            Thread.Sleep(1500);
            Console.WriteLine($"DONE with printing collection!");
            Console.WriteLine(new string('-', 20));
        }

        private static void AddCollectionToDb(List<User> collection)
        {
            Console.WriteLine("Adding collection into database table! Please wait....");
            foreach (var item in collection)
            {
                _ctx.Users.Add(item);
            }
            _ctx.SaveChanges();
            Thread.Sleep(1500);
            Console.WriteLine("DONE adding collection into database table!");
            Console.WriteLine(new string('-', 20));
        }

        private static void AddCollectionToDb(List<Sock> collection)
        {
            Console.WriteLine("Adding collection into database table! Please wait....");
            foreach (var item in collection)
            {
                _ctx.Socks.Add(item);
            }
            _ctx.SaveChanges();
            Thread.Sleep(1500);
            Console.WriteLine("DONE adding collection into database table!");
            Console.WriteLine(new string('-', 20));
        }

        #endregion

    }
}
