//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagement.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDERITEM
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public int Qty { get; set; }
        public int Total { get; set; }
        public Nullable<int> OrderID { get; set; }
    
        public virtual ITEM ITEM { get; set; }
        public virtual ORDER ORDER { get; set; }
    }
}
