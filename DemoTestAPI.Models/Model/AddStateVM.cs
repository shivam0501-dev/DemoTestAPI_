using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestAPI.Models.Model
{
    public class AddStateVM
    {
        [Required(ErrorMessage = "Please Enter State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Enter State Code")]

        public string StateCode { get; set; }
        [Required]
        public int CountryID { get; set; }

    }
}
