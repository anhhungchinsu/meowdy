

using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.Models.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliverySystem.BusinessLogicLayer.IServices
{
    public interface IDiscountDetailRepository : IGenericRepository<Discount_detail>
    {
        IEnumerable<Discount_detail> getDistincts();

        IEnumerable<Discount_detail> findById(short id);
    }
}
