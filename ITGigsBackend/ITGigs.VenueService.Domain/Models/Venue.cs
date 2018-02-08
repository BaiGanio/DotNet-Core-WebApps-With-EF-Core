using ITGigs.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ITGigs.VenueService.Domain.Models
{
    public sealed class Venue
    {
        private CustomId _id;
        private Venue() { }
        public Venue(string name, string address, string owner, int capacity, string imgUrl, CustomId id = null)
        {
            this.Name = name;
            this.Address = address;
            this.Owner = owner;
            this.Capacity = capacity;
            this.ImgUrl = imgUrl;
            this._id = id ?? new CustomId();
        }

        [Key]
        public string Id
        {
            get { return this._id.ToString(); }
            private set { this._id = new CustomId(new Guid(value)); }
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Owner { get; set; }

        public string ImgUrl { get; set; }

        public int Capacity { get; set; }

    }
}
