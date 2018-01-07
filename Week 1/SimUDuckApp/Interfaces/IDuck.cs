using System;

namespace SimUDuckApp
{
    public abstract class IDuck
    {
        private IQuackBehavior quackBehavior;

        public IDuck(IQuackBehavior qb)
        {
            this.quackBehavior = qb;
        }

        public void PerformQuack()
        {
            this.quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I'm swiming!");
        }
    }
}
