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
    
    public partial class ProjectContact
    {
        public int ContactId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
