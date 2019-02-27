using System;

namespace Chorap4e.ConsoleClient
{
    public sealed class User
    {
        public User() { }
        public User(string name, string pass)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Password = pass;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            string output = $"Юзер with ID: {this.Id} have име: {this.Name} и страшната парола: {this.Password}! ";
            return output;
        }
    }
}
