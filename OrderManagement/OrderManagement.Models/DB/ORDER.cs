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
    
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            this.ORDERITEMs = new HashSet<ORDERITEM>();
        }
    
        public int ID { get; set; }
        public Nullable<int> OrderBy { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public Nullable<int> PromoCode { get; set; }
        public int TotalPayable { get; set; }
    
        public virtual CouponCode CouponCode { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERITEM> ORDERITEMs { get; set; }
    }
}