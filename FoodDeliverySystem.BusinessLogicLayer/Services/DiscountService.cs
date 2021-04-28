using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliverySystem.BusinessLogicLayer.Services
{
    public class DiscountService : GenericRepository<Discount>, IDiscountRepository
    {
        public IEnumerable<Discount> GetDiscountsByUser(short id)
        {
            return Context.Discounts.Where(x => x.Discount_detail.Any(d => d.discount_detail_user_id == id));
        }
    }
}
