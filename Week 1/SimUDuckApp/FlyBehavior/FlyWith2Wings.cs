using System;

namespace SimUDuckApp.FlyBehavior
{
    public class FlyWith2Wings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Look I can fly!");
        }
    }
}
