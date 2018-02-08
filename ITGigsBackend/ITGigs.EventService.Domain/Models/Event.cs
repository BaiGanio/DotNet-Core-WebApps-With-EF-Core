using ITGigs.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITGigs.EventService.Domain.Models
{
    public sealed class Event
    {
        private CustomId _id;
        private Event() { }
        public Event(string name, string address, string owner, int capacity, string imgUrl, CustomId id = null)
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
