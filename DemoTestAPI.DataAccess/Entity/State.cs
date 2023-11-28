using DemoTestAPI.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTestAPI.DataAccess.Entity
{
    public class State:Base
    {
        public int StateId { get; set; }

        public string StateName { get; set; }

        public string StateCode { get; set; }
        public int CountryID { get; set; }

        [ForeignKey("CountryID")]
        public Country country { get; set; }
    }
}
