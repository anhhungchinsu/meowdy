//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodDeliverySystem.Models.DBContext
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Order_detail = new HashSet<Order_detail>();
            this.User_order = new HashSet<User_order>();
        }
    
        public short order_id { get; set; }
        public Nullable<System.DateTime> order_created_date { get; set; }
        public string order_status { get; set; }
        public string order_note { get; set; }
        public string order_payment_method { get; set; }
        public Nullable<decimal> order_service_charge { get; set; }
        public Nullable<decimal> order_transport_fee { get; set; }
        public string order_discount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order_detail> Order_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<User_order> User_order { get; set; }
    }
}