//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShaligramBuildcon_MVC.Models
{
    using System;
    
    public partial class sp_Products_Result
    {
        public int Product_Id { get; set; }
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
