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
    
    public partial class Order_detail
    {
        public short Order_detail_order_id { get; set; }
        public short Order_detail_food_id { get; set; }
        public Nullable<short> Order_detail_quantity { get; set; }
        [JsonIgnore]
        public virtual Food Food { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
