using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public static class DalRepository
    {
        public static List<Dish> DishList = new List<Dish>();
        public static List<Branch> BranchList = new List<Branch>();
        public static List<Ordered_Dish> OrderedDishList = new List<Ordered_Dish>();
        public static List<Order> OrderList = new List<Order>();
    }
}
