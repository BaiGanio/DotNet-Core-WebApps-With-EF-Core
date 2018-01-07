namespace SimUDuckApp
{
    public class RubberDuck : IDuck
    {
        public RubberDuck(IQuackBehavior qb) : base(qb)
        {
        }
    }
}
