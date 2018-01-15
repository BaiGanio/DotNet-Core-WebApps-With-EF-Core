namespace SimUDuckApp
{
    public class RedheadDuck : IDuck
    {
        public RedheadDuck(IQuackBehavior qb, IFlyBehavior fb) : base(qb, fb)
        {
        }
    }
}
