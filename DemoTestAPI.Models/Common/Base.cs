using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestAPI.Models.Common
{
    public class Base
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "Shivam Agrahari";
        public string? ModifiedBy { get; set; } = "Shivam Agrahari";
        public string? CreatedIP { get; set; } = "127.0.0.1";
        public string? ModifiedIP { get; set; } = "127.0.0.1";
    }
}
