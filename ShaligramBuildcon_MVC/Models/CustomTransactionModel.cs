using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Models
{
    public class CustomTransactionModel
    {
        public int Trx_id { get; set; }
        public Nullable<int> Member_id { get; set; }
        public Nullable<int> Product_id { get; set; }
        public string productname { get; set; }
        public Nullable<int> subproduct_id { get; set; }
        public string subproductname { get; set; }
        public int Required_Qty { get; set; }
        public decimal Total_Weight_given { get; set; }
        public Nullable<decimal> Total_weight_recieved { get; set; }
        public Nullable<int> Recieved_qty { get; set; }
       
        public System.DateTime Return_date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Actual_return_date { get; set; }
        public System.DateTime Valid_From { get; set; }
        public System.DateTime Valide_to { get; set; }
        public bool Is_completed { get; set; }
        public decimal Calculated_Piece_Labor_Rate { get; set; }
        public decimal Actual_piece_labor_rate { get; set; }
        public decimal Total_Actual_Amount { get; set; }
        public System.DateTime Order_date { get; set; }
        public decimal Piece_Labor_Rate { get; set; }
       
       
        public decimal transaction_amount { get; set; }
        public string PRtoPOItemDetailTableString { get; set; }
    }
}