using System;
using System.Collections.Generic;

namespace Chorap4e.Domain
{
    public sealed class User
    {
        public User() { }
        public User(string name, string pass, bool isLogged = false)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Password = pass;
            this.IsLogged = isLogged;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public bool IsLogged { get; set; }

        public override string ToString()
        {
            string output = $"Юзер with ID: {this.Id} have име: {this.Name} и страшната парола: {this.Password}! ";
            return output;
        }
    }
}
