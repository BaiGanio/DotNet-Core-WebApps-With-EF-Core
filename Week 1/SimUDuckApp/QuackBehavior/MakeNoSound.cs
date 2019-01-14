using System;

namespace SimUDuckApp
{
    class MakeNoSound : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("<<< Silence >>>");
        }
    }
}
