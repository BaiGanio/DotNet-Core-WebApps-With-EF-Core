using System;
using System.Linq;

namespace AuthManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Login: 1 \nRegister: 2 \nShow data: 3");
            Console.WriteLine("-----------------------------------------------");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //Login();
                    break;
                case "2":
                    //Register();
                    break;
                case "3":
                    FetchData();
                    break;
                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }


        }

        private static void FetchData()
        {
            GeographyEntities ctx = new GeographyEntities();

            var continets = ctx.Continents.ToList();
            var rivers = ctx.Rivers.ToList();

            foreach (var continet in continets)
            {
                Console.WriteLine(continet);
                Console.WriteLine("-------------------------");
            }

        }
    }
}
