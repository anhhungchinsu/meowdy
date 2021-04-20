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
    
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Menus = new HashSet<Menu>();
        }
    
        public short restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string restaurant_image { get; set; }
        public string restaurant_address { get; set; }
        public string restaurant_phone { get; set; }
        public string restaurant_email { get; set; }
        public Nullable<System.TimeSpan> restaurant_start_time { get; set; }
        public Nullable<System.TimeSpan> restaurant_end_time { get; set; }
        public Nullable<short> restaurant_user_id { get; set; }
        public Nullable<short> restaurant_category_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        public virtual ICollection<Menu> Menus { get; set; }
        [JsonIgnore]
        public virtual Restaurant_category Restaurant_category { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
