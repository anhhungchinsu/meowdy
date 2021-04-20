using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.Models.DBContext;

namespace FoodDeliverySystem.BusinessLogicLayer.IServices
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
    }
}
