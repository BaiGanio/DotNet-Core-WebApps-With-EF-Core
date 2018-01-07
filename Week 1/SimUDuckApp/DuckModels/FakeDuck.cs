namespace SimUDuckApp
{
    public class FakeDuck : IDuck
    {
        public FakeDuck(IQuackBehavior qb) : base(qb)
        {
        }
    }
}
