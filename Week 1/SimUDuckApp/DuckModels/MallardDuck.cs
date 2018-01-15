namespace SimUDuckApp
{
    public class MallardDuck : IDuck
    {
        public MallardDuck(IQuackBehavior qb, IFlyBehavior fb) : base(qb, fb)
        {
        }
    }
}
