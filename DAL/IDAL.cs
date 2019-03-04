using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        void addDish(Dish d);
        void removeDish(Dish d);
        void changeDish(Dish d);
        void addBranch(Branch b);
        void removeBranch(Branch b);
        void changeBranch(Branch b);
        int addOrder(Order o);
        void removeOrder(Order o);
        int changeOrder(Order o);
        void addOrderedDish(Ordered_Dish o);
        void removeOrderedDish(Ordered_Dish o);
        void changeOrderedDish(Ordered_Dish o);
        IEnumerable<Order> getAllOrders();
        IEnumerable<Dish> getAllDishs();
        IEnumerable<Branch> getAllBranches();
        bool existDish(int id);
        bool existOrder(int id);
        bool existOrderedDish(int id);
        bool existBranch(int id);
        IEnumerable<Ordered_Dish> getOrders(Func<Ordered_Dish, bool> predicate = null);
        IEnumerable<Ordered_Dish> getAllOrderedDishes();
    }
}
