using FoodDeliverySystem.BusinessLogicLayer.BaseServices;
using FoodDeliverySystem.BusinessLogicLayer.IServices;
using FoodDeliverySystem.BusinessLogicLayer.Services;
using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IDiscountDetailRepository _discountDetailRepository = new DiscountDetailService();
        static void Main(string[] args)
        {
            var lt = _discountDetailRepository.GetAll().GroupBy(m => m.discount_detail_user_id).Select(x => x.FirstOrDefault());

            foreach (var item in lt)
            {
                Console.WriteLine(item.discount_detail_user_id);
            }
            Console.ReadKey();
        }
    }
}
