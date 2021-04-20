using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.Models.DBContext;
using System.Collections.Generic;

namespace FoodDeliverySystem.BusinessLogicLayer.IServices
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        IEnumerable<Discount> GetDiscountsByUser(short id);
    }
}
