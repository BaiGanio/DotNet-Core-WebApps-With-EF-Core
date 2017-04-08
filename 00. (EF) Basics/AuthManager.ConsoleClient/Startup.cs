using System;

namespace AuthManager.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            //TasksStatePreview();
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
            Console.WriteLine($"{helloMsg, 60}");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine();
            Console.WriteLine("|---------------------------------------------|");
            Console.WriteLine($"{"|Task",-32} | {"Task state", 5} |");
            Console.WriteLine("|---------------------------------------------|");
            foreach (var item in tasks)
            {
                if (item.Equals("Nothing done yet"))
                {
                    Console.WriteLine($"|{item,-31} | {taskStates[1],10} |");
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
