using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class ProductSubProductRelations
    {
        public int PSR_id { get; set; }
        public int Product_id { get; set; }
        public int SubProduct_id { get; set; }
        public decimal Required_qty { get; set; }
    }
}   