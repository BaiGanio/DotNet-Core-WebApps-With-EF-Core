using System;

namespace AthManager.Model
{
    public sealed class User// : IBaseUser
    {
        //public User(string firstName, string lastName, string town, string password, string email,
        //    TypeOfUser typeOfUser, DateTime dataSavedOn, bool isRegistered, DateTime? dataChangedOn, string ipAddress = null, string id = null) 
        //    : base(firstName, lastName, town, dataSavedOn, isRegistered, ipAddress, id)
        //{
        //    this.TypeOfUser = typeOfUser;
        //    this.Password = HashUtils.CreateHashCode(password);
        //    this.Email = email;
        //    this.DataChangedOn = dataChangedOn;
        //}

        //public string Password { get; set; }
        //public string Email { get; set; }
        //public DateTime? DataChangedOn { get; set; }

        //public override string Introduce()
        //{ 
        //    string dateChanged = string.IsNullOrEmpty(this.DataChangedOn.ToString()) ? "N/A" : this.DataChangedOn.ToString();
        //    string msg = base.Introduce();
        //    msg += 
        //        $"\nPassword: {this.Password} " +
        //        $"\nEmail: {this.Email} " +
        //        $"\nData changed on: {dateChanged}";
        //    return msg;
        //}
    }
}
