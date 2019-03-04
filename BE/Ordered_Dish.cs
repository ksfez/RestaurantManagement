using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ordered_Dish
    {

        public int Order_ID { get; set; }
        public int Dish_ID { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            string result = "Ordered Dish details:";
            result += string.Format("\t order ID:{0} \n dish ID:{1} \n quantity:{2}", Order_ID, Dish_ID, Quantity);
            return result;
        }
    }
}

