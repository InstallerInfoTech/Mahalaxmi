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
    
    public partial class parentmenulist_Result
    {
        public int MenuId { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> DispalyOrder { get; set; }
    }
}
