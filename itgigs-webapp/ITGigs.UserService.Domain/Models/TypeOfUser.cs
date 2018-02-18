
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ITGigs.UserService.Domain.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfUser
    {
        [EnumMember(Value = "Visitor")]
        Visitor = 1,
        [EnumMember(Value = "Performer")]
        Performer = 2,
        [EnumMember(Value = "Venue owner")]
        VenueOwner = 3,
        [EnumMember(Value = "Admin")]
        Admin = 4
    }
}
