using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestAPI.Models.Model
{
    public class StateVM
    {
        public int? StateId { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Enter State Code")]

        public string StateCode { get; set; }
        [Required]
        public int CountryID { get; set; }

    }
}
