using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Common
{
    public class JsonFormatter
    {
        public static string Format(IEnumerable list)
        {
            string rs = JsonConvert.SerializeObject(list, Formatting.None);
            string data = Regex.Replace(rs, @"\\r\\n", "");
            string finaldata = Regex.Replace(data, @"\\""", "");
            return finaldata;
        }
    }
}
