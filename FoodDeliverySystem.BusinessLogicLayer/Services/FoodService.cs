using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;

namespace FoodDeliverySystem.BusinessLogicLayer.Services
{
    public class FoodService : GenericRepository<Food>, IFoodRepository
    {
    }
}
