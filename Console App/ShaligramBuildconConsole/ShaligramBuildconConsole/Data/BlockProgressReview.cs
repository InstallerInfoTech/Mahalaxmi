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
    
    public partial class BlockProgressReview
    {
        public int ReviewId { get; set; }
        public int ProgressId { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public bool IsCompleted { get; set; }
    
        public virtual BlockProgress BlockProgress { get; set; }
    }
}
