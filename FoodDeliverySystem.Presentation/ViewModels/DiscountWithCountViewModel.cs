using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Presentation.ViewModels
{
    public class DiscountWithCountViewModel
    {
        public Discount Discount { get; set; }
        public IEnumerable <Discount_detail> Discount_Details { get; set; }
        public int Count;
    }
}