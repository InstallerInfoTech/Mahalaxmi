using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class CustomMemberModel
    {
        public int Member_id { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Contact_no { get; set; }
        public string Alternate_conatact_no { get; set; }
        public string Address { get; set; }
        public string Aadhar { get; set; }
        public int Deposit_Amount { get; set; }
        public bool Status { get; set; }
        public System.DateTime Created_at { get; set; }
        public System.DateTime Updated_at { get; set; }
        public int member_Category_id { get; set; }
        public string FullName { get; set; }
    }
}