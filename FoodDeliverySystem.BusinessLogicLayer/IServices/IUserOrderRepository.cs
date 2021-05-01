using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.BusinessLogicLayer.IServices
{
    public interface IUserOrderRepository : IGenericRepository<User_order>
    {
    }
}
