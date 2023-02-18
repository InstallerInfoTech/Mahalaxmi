using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class ProductRMRelation
    {
        public int PRM_id { get; set; }
        public int Product_id { get; set; }
        public int Rawmaterial_id { get; set; }
        public decimal Required_qty { get; set; }
        public string unit_type { get; set; }
    }
}