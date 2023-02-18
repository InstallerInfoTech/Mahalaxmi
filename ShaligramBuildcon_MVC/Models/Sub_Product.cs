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
    
    public partial class Sub_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sub_Product()
        {
            this.Product_Subproduct_relation = new HashSet<Product_Subproduct_relation>();
            this.Subproduct_RM_usage = new HashSet<Subproduct_RM_usage>();
            this.Transaction_details = new HashSet<Transaction_details>();
        }
    
        public int SubProduct_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SKU { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public bool Active { get; set; }
        public int Location_id { get; set; }
        public byte[] image_url { get; set; }
        public int Labour_rate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Subproduct_relation> Product_Subproduct_relation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subproduct_RM_usage> Subproduct_RM_usage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction_details> Transaction_details { get; set; }
    }
}
