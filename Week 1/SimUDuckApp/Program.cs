using SimUDuckApp.FlyBehavior;
using System;

namespace SimUDuckApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDuck[] ducks = new IDuck[]
            {
                new MallardDuck(new QuackWithSound(), new FlyWith2Wings()),
                new RedheadDuck(new QuackWithSound(), new FlyWith2Wings()),
                new FakeDuck(new MakeNoSound(), new FlyNoWay()),
                new RubberDuck(new Squeak(), new FlyNoWay())
            };


            foreach (var duck in ducks)
            {
                if (duck.GetType().Name == "RubberDuck")
                {
                    duck.SetFlyBehavior(new FlyWithRocket());
                }
                Console.WriteLine("Duck of type {0}", duck.GetType().Name);
                duck.PerformQuack();
                duck.PerformFly();
                duck.Swim();
                Console.WriteLine("========================");
                
            }
        }
    }
}
