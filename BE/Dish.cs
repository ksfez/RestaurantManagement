using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Dish
    {
        public int Dish_ID { get; set; }
        public string DishName { get; set; }
        public DishSize Godel { get; set; }
        public double Price { get; set; }
        public Hechsher RamatHechsher { get; set; }
        public int Counter { get; set; }
        public override string ToString()
        {
            string result = "Dish Details: \n";
            result += string.Format("\tDish name: {0}\n", DishName);
            result += string.Format("the id is {0} and the hechsher is {1}\n", Dish_ID, RamatHechsher);
            return result;
        }
    }
}
