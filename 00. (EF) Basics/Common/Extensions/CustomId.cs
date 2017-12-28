namespace Common.Extensions
{
    public class CustomId
    {
        private Guid id;

        public CustomId()
        {
            this.id = Guid.NewGuid();
        }

        public CustomId(Guid guid)
        {
            this.id = guid;
        }

        public override string ToString()
        {
            return this.id.ToString();
        }
    }
}
