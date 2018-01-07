using System;

namespace SimUDuckApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDuck[] ducks = new IDuck[]
            {
                new MallardDuck(new QuackWithSound()),
                new RedheadDuck(new QuackWithSound()),
                new FakeDuck(new MakeNoSound()),
                new RubberDuck(new Squeak())
            };


            foreach (var duck in ducks)
            {
                Console.WriteLine("Duck of type {0}", duck.GetType().Name);
                duck.PerformQuack();
                duck.Swim();
                Console.WriteLine("========================");
            }
        }
    }
}
