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
    using System.Collections.Generic;
    
    public partial class Raw_material_supplier_relation
    {
        public int RMS_id { get; set; }
        public int supplier_id { get; set; }
        public int Rawmaterial_Id { get; set; }
    
        public virtual Raw_Material Raw_Material { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
