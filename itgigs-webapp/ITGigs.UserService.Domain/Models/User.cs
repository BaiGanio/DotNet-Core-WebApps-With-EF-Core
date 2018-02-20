using ITGigs.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITGigs.UserService.Domain.Models
{
    public sealed class User
    {
        private CustomId _id;

        public User() { }

        public User(string Username, CustomId id = null, string imgUrl = null,
            DateTime? dateCreated = null, DateTime? dateChanged = null)
        {
            this.Username = Username;
            this.ImgUrl = imgUrl ?? string.Empty;
            this.DateCreated = dateCreated ?? DateTime.Now;
            this.DateChanged = dateChanged ?? DateTime.MinValue;
            this._id = id ?? new CustomId();
        }

        public User(string username, string email, string password, TypeOfUser typeOfUser, string validationCode = null,
            bool isEmailConfirmed = false, CustomId id = null, string imgUrl = null, DateTime? dateChanged = null)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.TypeOfUser = typeOfUser;
            this.ValidationCode = validationCode;
            this.IsEmailConfirmed = isEmailConfirmed;
            this.DateCreated = DateTime.Now;
            this.ImgUrl = imgUrl ?? string.Empty;
            this.DateChanged = dateChanged ?? DateTime.MinValue;
            this._id = id ?? new CustomId();
        }

        [Key]
        public string Id
        {
            get { return this._id.ToString(); }
            private set { this._id = new CustomId(new Guid(value)); }
        }

        public string Username { get; private set; }

        public string ImgUrl { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public TypeOfUser TypeOfUser { get; private set; }

        public string ValidationCode { get; private set; }

        public bool IsEmailConfirmed { get; private set; }

        public DateTime? DateCreated { get; private set; }

        public DateTime? DateChanged { get; private set; }

    }
}
