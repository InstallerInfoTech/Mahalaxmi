//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShaligramBuildconConsole.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingDetail
    {
        public int DetailId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectUnitId { get; set; }
        public int ProjectPropertyId { get; set; }
        public int MemberId { get; set; }
        public int BookedBy { get; set; }
        public System.DateTime BookingDate { get; set; }
        public bool IsAvailableForResale { get; set; }
        public Nullable<bool> IsResaled { get; set; }
        public string Note { get; set; }
        public string SelectedFlatNo { get; set; }
        public Nullable<decimal> SaleValue { get; set; }
        public Nullable<decimal> ReceivingValue { get; set; }
        public Nullable<decimal> RemainingValue { get; set; }
        public Nullable<bool> IsCommercial { get; set; }
        public Nullable<int> AgreementNumber { get; set; }
        public Nullable<System.DateTime> AgreementDate { get; set; }
        public Nullable<int> SaleDeedNumber { get; set; }
        public Nullable<System.DateTime> SaleDeedDate { get; set; }
        public Nullable<int> BankName { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public string LoanAccountNumber { get; set; }
        public string Branch { get; set; }
        public string City { get; set; }
        public Nullable<int> EntryBy { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectUnitPropertyDetail ProjectUnitPropertyDetail { get; set; }
        public virtual ProjectUnitBlock ProjectUnitBlock { get; set; }
    }
}
