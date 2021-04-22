using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Presentation.ViewModels
{
    public class MenuDetailViewModel
    {
        public Menu Menu { get; set; }
        public IEnumerable<Food> Foods { get; set; }
    }
}