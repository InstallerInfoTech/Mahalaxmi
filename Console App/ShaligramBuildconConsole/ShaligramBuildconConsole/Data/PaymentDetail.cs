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
    
    public partial class PaymentDetail
    {
        public int PaymentDetailId { get; set; }
        public int PaymentMasterId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int ProjectPropertyId { get; set; }
        public int ProjectPlanPhaseId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceiveAmount { get; set; }
        public decimal RemaingAmount { get; set; }
        public bool IsPhaseCompleted { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual PaymentMaster PaymentMaster { get; set; }
        public virtual PaymentPlan PaymentPlan { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectUnitPropertyDetail ProjectUnitPropertyDetail { get; set; }
    }
}
