using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AthManager.Model;
using AuthManager.DB;

namespace AuthManager.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //TasksStatePreview();
            //PrintObjectsInfo();            
            List<AppConsumer> appConsumers = GetDefaultAppConsumers();
            List<User> users = GetDefaultUsers();
            var context = new AuthManagerDbContext();
            context.Database.Initialize(true);


            if (!context.AppConsumers.Any())
            {
                foreach (var item in appConsumers)
                {
                    context.AppConsumers.Add(item);
                }
            }

            if (!context.Users.Any())
            {
                foreach (var item in users)
                {
                    context.Users.Add(item);
                }
            }

           
            context.SaveChanges();


            Console.WriteLine("Database is populated!");

        }


        private static void PrintObjectInfo(IBaseUser user)
        {
            Console.WriteLine(user.Introduce());
        }

        private static void PrintObjectsInfo()
        {
            List<User> users = GetDefaultUsers();
            List<AppConsumer> appConsumers = GetDefaultAppConsumers();

            PrintObjectInfo(users[0]);

            //foreach (var item in users)
            //{
            //    PrintObjectInfo(item);
            //    Console.WriteLine("----------------------------------------------------");
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine("#########################################################");
            Console.WriteLine();

            PrintObjectInfo(appConsumers[0]);

            //foreach (var item in appConsumers)
            //{
            //    PrintObjectInfo(item);
            //    Console.WriteLine("----------------------------------------------------");
            //    Console.WriteLine();
            //}
        }

        private static List<User> GetDefaultUsers()
        {
            List<User> users = new List<User>();

            User lyuben = new User("Lyuben", "Kikov", "Aksakovo", "123", "fake@mail.com", TypeOfUser.Кибик, DateTime.Now, false, null);
            User bunny = new User("Bugs", "Bunny", "Acme", "123", "bunny@mail.com", TypeOfUser.Singer, DateTime.Now, false, null);
            User daffy = new User("Daffy", "Duck", "Acme", "123", "duck@mail.com", TypeOfUser.Writer, DateTime.Now, false, null);
                        
            users.Add(lyuben);
            users.Add(bunny);
            users.Add(daffy);

            return users;
        }

        private static List<AppConsumer> GetDefaultAppConsumers()
        {
            List<AppConsumer> appConsumers = new List<AppConsumer>();

            AppConsumer taz = new AppConsumer("Tazmanian", "Devil", "Sidney", DateTime.Now, false);
            AppConsumer fiki = new AppConsumer("Fiki", "Kra4eto", "4irpan", DateTime.Now, false);
            AppConsumer bygi = new AppConsumer("Bygi", "Barabata", "Kaspi4an", DateTime.Now, false);
            
            appConsumers.Add(taz);
            appConsumers.Add(fiki);
            appConsumers.Add(bygi);

            return appConsumers;
        }

        private static void TasksStatePreview()
        {
            string helloMsg = "Hello from Athentication Manager Tasks Preview!";
            char[] taskStates = new char[] { 'X', '\u2713' };
            string[] tasks =
            {
                "Create models logic",
                "Save current app consumer state",
                "Login user",
                "Register user",
                "Retrieve application info",
                "Nothing done yet"
            };

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{helloMsg,60}");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine();
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine($"{"|Task",-32} | {"Task state",5} |");
            Console.WriteLine("|---------------------------------------------|");
            foreach (var item in tasks)
            {
                if (item.Equals("Nothing done yet"))
                {
                    Console.WriteLine($"|{item,-31} | {taskStates[1],9} |");
                }
                else
                {
                    Console.WriteLine($"|{item,-31} | {taskStates[0],10} |");
                }
            }
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine();
        }
    }
}
