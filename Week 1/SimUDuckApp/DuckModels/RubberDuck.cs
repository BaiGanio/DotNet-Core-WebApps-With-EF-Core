namespace SimUDuckApp
{
    public class RubberDuck : IDuck
    {
        public RubberDuck(IQuackBehavior qb, IFlyBehavior fb) : base(qb, fb)
        {
        }
    }
}
