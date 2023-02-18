using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class CustomTranDetails
    {
        public int? Trxdetails_id { get; set; }
        public string product_name { get; set; }
        public string subproduct_name { get; set; }
        public string type { get; set; }    
        public string Material { get; set; } 
        public decimal Totalqty { get; set; }    
        public string unit_type { get; set; }   
        public decimal Given_qty { get; set;}
        public bool status { get; set; }
    }
}