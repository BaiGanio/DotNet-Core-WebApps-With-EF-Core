using System;

namespace SimUDuckApp
{
    public abstract class IDuck
    {
        private IQuackBehavior quackBehavior;
        private IFlyBehavior flyBehavior;

        public IDuck(IQuackBehavior qb)
        {
            this.quackBehavior = qb;
            //this.flyBehavior= new fly
        }

        public IDuck(IQuackBehavior qb, IFlyBehavior fb)
        {
            this.quackBehavior = qb;
            this.flyBehavior = fb;
        }

        public void PerformQuack()
        {
            this.quackBehavior.Quack();
        }

        public void PerformFly()
        {
            this.flyBehavior.Fly();
        }

        //public void PerformDive()
        //{
        //    this.diveBehavior.Dive();
        //}

        public void SetFlyBehavior(IFlyBehavior fb)
        {
            this.flyBehavior = fb;
        }


        public void Swim()
        {
            Console.WriteLine("I'm swiming!");
        }
    }
}
