namespace SimUDuckApp
{
    public class FakeDuck : IDuck
    {
        public FakeDuck(IQuackBehavior qb, IFlyBehavior fb) : base(qb, fb)
        {
        }
    }
}
