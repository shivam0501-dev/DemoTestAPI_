using DemoTestAPI.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DemoTestAPI.DataAccess.Entity
{
    public class Country:Base
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
