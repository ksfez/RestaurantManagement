using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;


namespace DAL
{
    public class ListDal:IDAL 
    {
        private static int IDdish = 0;

        public void addDish(Dish d)
        {
            DalRepository.DishList.Add(new Dish
            {
                Dish_ID = ++IDdish,
                DishName = d.DishName.ToUpper(),
                Godel = d.Godel,
                Price = d.Price,
                RamatHechsher = d.RamatHechsher
            }
            );
        }
        public void removeDish(Dish d)
        {
            DalRepository.DishList.Remove(d);
        }
        public void changeDish(Dish d)
        {
            DalRepository.DishList.RemoveAll(e => e.Dish_ID == d.Dish_ID);
            DalRepository.DishList.Add(d);
        }
        private static int IDbranch = 0;
        public void addBranch(Branch b)
        {
            b.BranchNum = ++IDbranch;
            DalRepository.BranchList.Add(b);
        }
        public void removeBranch(Branch b)
        {
            DalRepository.BranchList.Remove(b);
        }
        public void changeBranch(Branch b)
        {
            DalRepository.BranchList.RemoveAll(d => d.BranchNum == b.BranchNum);
            DalRepository.BranchList.Add(b);
        }
        static int OrderID = 0;
        public int addOrder(Order o)
        {
            o.Order_ID = ++OrderID;
            DalRepository.OrderList.Add(o);
            return o.Order_ID;
        }
        public void removeOrder(Order o)
        {
            DalRepository.OrderList.Remove(o);
        }
        public int changeOrder(Order o)
        {
            DalRepository.OrderList.RemoveAll(d => d.Order_ID == o.Order_ID);
            DalRepository.OrderList.Add(o);
            return o.Order_ID;

        }
        public void addOrderedDish(Ordered_Dish o)
        {
            DalRepository.OrderedDishList.Add(o);
        }
        public void removeOrderedDish(Ordered_Dish o)
        {
            DalRepository.OrderedDishList.Remove(o);

        }
        public void changeOrderedDish(Ordered_Dish o)
        {
            DalRepository.OrderedDishList.RemoveAll(d => d.Dish_ID == o.Dish_ID);
            DalRepository.OrderedDishList.Add(o);
        }
        public IEnumerable<Ordered_Dish> getAllOrderedDishes()
        {
            return DalRepository.OrderedDishList.ToList();
        }
        public IEnumerable<Order> getAllOrders()
        {
            return DalRepository.OrderList.ToList();
        }
        public IEnumerable<Dish> getAllDishs()
        {
            return DalRepository.DishList.ToList();

        }
        public IEnumerable<Branch> getAllBranches()
        {
            return DalRepository.BranchList.ToList();
        }
        public bool existDish(int id)
        {
            var v = from item in DalRepository.DishList
                    where item.Dish_ID == id
                    select item;
            foreach (var item in v)
                if (item != null)
                    return true;
            return false;
        }
        public bool existBranch(int id)
        {
            var v = from item in DalRepository.BranchList
                    where item.BranchNum == id
                    select item;
            foreach (var item in v)
                if (item != null)
                    return true;
            return false;
        }
        public bool existOrder(int id)
        {
            var v = from item in DalRepository.OrderList
                    where item.Order_ID == id
                    select item;
            foreach (var item in v)
                if (item != null)
                    return true;
            return false;
        }
        public bool existOrderedDish(int id)
        {
            var v = from item in DalRepository.OrderedDishList
                    where item.Order_ID == id
                    select item;
            foreach (var item in v)
                if (item != null)
                    return true;
            return false;
        }
        public IEnumerable<Ordered_Dish> getOrders(Func<Ordered_Dish, bool> predicate = null)
        {
            if (predicate == null)
                return DalRepository.OrderedDishList;
            return DalRepository.OrderedDishList.Where(predicate);
        }
    }
}

