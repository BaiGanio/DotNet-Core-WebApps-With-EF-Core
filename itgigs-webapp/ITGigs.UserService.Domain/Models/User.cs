using ITGigs.Common.Extensions;
using System;
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
        public User(string username, string email, string password, string imgUrl = null, CustomId id = null)
        {
            this.Username = username;
            this.Email = email;
            this.ImgUrl = imgUrl ?? string.Empty;
            this.Password = password;
            this.DateCreated = DateTime.Now;
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

        public DateTime? DateCreated { get; private set; }

        public DateTime? DateChanged { get; private set; }

    }
}
