using System;
using Project.Common;

namespace AthManager.Model
{
    public abstract class IBaseUser
    {
        public IBaseUser(string firstName, string lastName, string town, DateTime dataSavedOn, bool isRegistered, string ipAddress = null, string id = null)
        {
            this.Id = id ?? new CustomId().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Town = town;
            this.IpAddress = ipAddress ?? IPHelper.GetIpAddress();
            this.DataSavedOn = dataSavedOn;
            this.IsRegistered = isRegistered;
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Town { get; set; }
        public TypeOfUser TypeOfUser { get; set; }
        public string IpAddress { get; set; }
        public DateTime DataSavedOn { get; private set; }
        public bool IsRegistered { get; set; }

        public virtual string Introduce()
        {
            string fullName = $"{FirstName} {LastName}";
            string msg = 
                $"ID: {this.Id} " +
                $"\nHello from {fullName} " +
                $"\nTown: {this.Town} " +
                $"\nType of User: {this.TypeOfUser}" +
                $"\nDate saved on: {this.DataSavedOn} " +
                $"\nIs registered: {this.IsRegistered} " +
                $"\nIP address: {this.IpAddress}";
            return msg;
        }
    }
}
