using System.ComponentModel.DataAnnotations;

namespace AuthManager2
{
    public class Country
    {
        [Key]
        public string CountryCode { get; set; }
        public string IsoCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public string ContinentCode { get; set; }
        public int Population { get; set; }
        public int AreaInSqKm { get; set; }
        public string Capital { get; set; }

    }
}