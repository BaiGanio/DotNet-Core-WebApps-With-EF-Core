using ITGigs.Common.Extensions;
using ITGigs.UserService.Domain.Models;
using ITGigs.VenueService.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ITGigs.ITGigService.Domain.Models
{
    public class ITGig
    {
        private CustomId _id;

        public ITGig() { }
        public ITGig(string name, CustomId id = null) { this._id = id ?? new CustomId(); }
        public ITGig(string name, string performerId, string venueId, string imgUrl, int ticketPrice, CustomId id = null)
        {
            this.Name = name;
            this.PerformerId = performerId;
            this.VenueId = venueId;
            this.ImgUrl = imgUrl;
            this.TicketPrice = ticketPrice;
            //this.Id = string.IsNullOrEmpty(id.ToString()) ? new CustomId().ToString() : id.ToString();
            this._id = id ?? new CustomId();
        }

        [Key]
        public string Id
        {
            get { return this._id.ToString() ?? new CustomId().ToString(); }
            private set { this._id = new CustomId(new Guid(value)); }
        }

        public string Name { get; private set; }

        public string PerformerId { get; private set; }

        public virtual User Performer { get; private set; }

        public string VenueId { get; private set; }

        public virtual Venue Venue { get; private set; }

        public string ImgUrl { get; private set; }

        public int TicketPrice { get; private set; }
    }
}
