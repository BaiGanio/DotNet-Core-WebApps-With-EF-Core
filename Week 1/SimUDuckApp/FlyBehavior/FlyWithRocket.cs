using System;

namespace SimUDuckApp.FlyBehavior
{
    class FlyWithRocket : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Look at me I'm the flying duck!");
        }
    }
}
