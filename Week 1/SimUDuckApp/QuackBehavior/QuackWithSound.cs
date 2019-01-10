using System;

namespace SimUDuckApp
{
    public class QuackWithSound : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack it!");
        }
    }
}
