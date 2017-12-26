namespace AuthManager452.Models
{
    public class FunkyUser
    {
        public FunkyUser() { }

        public FunkyUser(int funckyId, string funckyName, string funckyPassword)
        {
            this.Id = funckyId;
            this.FunckyName = funckyName;
            this.FunckyPassword = funckyPassword;
        }

        public int Id { get; set; }

        public string FunckyName { get; set; }

        public string FunckyPassword { get; set; }
    }
}
