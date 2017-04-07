using System;
using System.ComponentModel.DataAnnotations;
using Project.Common;

namespace Project.Models
{
    public class User
    {
        public User(string username, string password, bool isValidated, string id = null)
        {
            this.Id = id ?? Guid.NewGuid().ToString();
            this.Username = username;
            this.Password = HashUtils.CreateHashCode(password);
            this.IsValidated = isValidated;
        }

        [Key]
        public string Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool IsValidated { get; private set; }

        public override string ToString()
        {
            return $"User: {this.Username} \nwith ID: {this.Id} \nPassword: {this.Password}";
        }

    }
}
