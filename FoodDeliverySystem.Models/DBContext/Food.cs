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
    
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            this.Order_detail = new HashSet<Order_detail>();
        }
    
        public short food_id { get; set; }
        public string food_name { get; set; }
        public Nullable<decimal> food_price { get; set; }
        public Nullable<short> food_quantity { get; set; }
        public string food_image { get; set; }
        public Nullable<short> food_served { get; set; }
        public string food_note { get; set; }
        public Nullable<short> food_menu_id { get; set; }
        [JsonIgnore]
        public virtual Menu Menu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order_detail> Order_detail { get; set; }
    }
}
