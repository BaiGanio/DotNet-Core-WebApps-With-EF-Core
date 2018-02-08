using ITGigs.Common.Extensions;
using ITGigs.ITGigService.Domain.Models;
using ITGigs.UserService.Domain.Models;
using ITGigs.VenueService.Domain.Models;
using System;
using System.Collections.Generic;

namespace ITGigs.DB.Helpers
{
    public static class Constants
    {
        

        public static List<Venue> GetInitialVenues()
        {
            return new List<Venue>()
            {
                new Venue(
                    "ЕТ 'Road House - Крайпътна къща' - Минчо М.",
                    "Аксаково вилидж",
                    "Минчо Минчев",
                    200,
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Windmill_Bar%2C_Cricklewood%2C_NW2_%285695942466%29.jpg/1200px-Windmill_Bar%2C_Cricklewood%2C_NW2_%285695942466%29.jpg",
                    new CustomId(new Guid("296ea834-9c20-4741-b4bd-310aa535bef8"))
                ),
                new Venue(
                    "Dirty Duck LTD.",
                    "Пловдив area",
                    "Гецата Първанов",
                    350,
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/Kiernan_Building_-_Portland%2C_Oregon.jpg/1200px-Kiernan_Building_-_Portland%2C_Oregon.jpg",
                    new CustomId(new Guid("d7289be4-836d-47fe-b0dd-d19d1aae9f77"))
                )
            };
        }

        


    }
}
