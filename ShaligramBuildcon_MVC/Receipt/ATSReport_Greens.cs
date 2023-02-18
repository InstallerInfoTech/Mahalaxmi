namespace ShaligramBuildcon_MVC.Receipt
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ATSReport.
    /// </summary>
    public partial class ATSReport_Greens : Telerik.Reporting.Report
    {
        public ATSReport_Greens()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //this.table3.Bindings.Add(new Telerik.Reporting.Binding("Parent.Visible", "=IIf(Fields.ProjectId = 1,False,True)"));
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}