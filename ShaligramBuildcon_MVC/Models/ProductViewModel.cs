using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class ProductViewModel
    {
        
        public int Product_Id { get; set; }
        [Display(Name = "Please etner product name"), Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int SKU { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public bool Active { get; set; }
        public int Category_id { get; set; }
        public int Location_id { get; set; }
        public byte[] image_url { get; set; }
        public int Labor_Rate { get; set; }
    }
}