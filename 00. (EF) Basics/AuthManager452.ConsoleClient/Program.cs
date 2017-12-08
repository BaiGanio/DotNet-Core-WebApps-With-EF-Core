using AuthManager452.DB;
using AuthManager452.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthManager452.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FunckyUser> funckyUsers = InitializeDefaultFunckyUsers();
            SeedDB(funckyUsers);
            Console.WriteLine("------------------------------------");
            PrintAktiveUsers();
           

        }


        private static void TasksStatePreview()
        {
            string helloMsg = "Hello from Athentication Manager 4.5.2Tasks Preview!";
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
                else if (item.Equals("Register user"))
                {
                    Console.WriteLine($"|{item,-31} | {"press 4",9} |");
                }
                else
                {
                    Console.WriteLine($"|{item,-31} | {taskStates[0],10} |");
                }
            }
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine();
        }       

        private static void SeedDB(List<FunckyUser> funckyUsers)
        {
            var context = new AuthManager452DbContext();
            context.Database.Initialize(true);

            if (!context.FunckyUsers.Any())
            {
                foreach (var item in funckyUsers)
                {
                    context.FunckyUsers.Add(item);
                }
                Console.WriteLine("Database is populated!");
                Console.WriteLine("------------------------------------");
                PriPrintAktiveUsers(funckyUsers);
            }
            else
            {
                Console.WriteLine("DB already initialized!");
            }

            context.SaveChanges();
        }

        private static void PrintAktiveUsers()
        {
            var context = new AuthManager452DbContext();
            context.Database.Initialize(true);
            List<FunckyUser> funckyUsers = context.FunckyUsers.ToList();
            Console.WriteLine("Users:");
            foreach (var item in funckyUsers)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.FunckyName}");
                Console.WriteLine($"Pass: {item.FunckyPassword}");
                Console.WriteLine("---------");
            }
        }

        private static void PriPrintAktiveUsers(List<FunckyUser> funckyUsers)
        {
            Console.WriteLine("Users:");
            foreach (var item in funckyUsers)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.FunckyName}");
                Console.WriteLine($"Pass: {item.FunckyPassword}");
                Console.WriteLine("---------");
            }
        }

        private static List<FunckyUser> InitializeDefaultFunckyUsers()
        {
            List<FunckyUser> users = new List<FunckyUser>();

            FunckyUser lyuben = new FunckyUser(1, "Lyuben Kikov", "123");
            FunckyUser bunny = new FunckyUser(2, "Bugs Bunny", "123");
            FunckyUser daffy = new FunckyUser(3, "Daffy Duck", "123");

            users.Add(lyuben);
            users.Add(bunny);
            users.Add(daffy);

            return users;
        }
    }
}
