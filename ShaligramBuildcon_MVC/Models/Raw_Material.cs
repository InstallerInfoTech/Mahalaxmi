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
    
    public partial class Raw_Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Raw_Material()
        {
            this.Product_RM_usage = new HashSet<Product_RM_usage>();
            this.Raw_material_supplier_relation = new HashSet<Raw_material_supplier_relation>();
            this.Subproduct_RM_usage = new HashSet<Subproduct_RM_usage>();
            this.Transaction_details = new HashSet<Transaction_details>();
        }
    
        public int Rawmaterial_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SKU { get; set; }
        public int unit_id { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public bool Active { get; set; }
        public int Category_id { get; set; }
        public int Location_id { get; set; }
        public byte[] image_url { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual Measurement_unit Measurement_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_RM_usage> Product_RM_usage { get; set; }
        public virtual Rawmaterial_Category Rawmaterial_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Raw_material_supplier_relation> Raw_material_supplier_relation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subproduct_RM_usage> Subproduct_RM_usage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction_details> Transaction_details { get; set; }
    }
}
