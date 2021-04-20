using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliverySystem.BusinessLogicLayer.Services
{
    public class DiscountDetailService : GenericRepository<Discount_detail>, IDiscountDetailRepository
    {
        public IEnumerable<Discount_detail> getDistincts()
        {
            return Context.Discount_detail.GroupBy(m => m.discount_detail_user_id).Select(x => x.FirstOrDefault());
        }
    }
}
