using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.BusinessLogicLayer.Services
{
    public class UserService : GenericRepository<User>, IUserRepository
    {
    }
}
