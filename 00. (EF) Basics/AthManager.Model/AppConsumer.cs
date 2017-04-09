using System;

namespace AthManager.Model
{
    public sealed class AppConsumer : BaseUser
    {
        public AppConsumer(string firstName, string lastName, string town, DateTime dataSavedOn,
            bool isRegistered, string ipAddress = null, string id = null) 
            : base(firstName, lastName, town, dataSavedOn, isRegistered, ipAddress, id)
        {
        }
    }
}
