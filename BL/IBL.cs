using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void addDish(Dish mydish);
        void removeDish(int id);
        void changeDish(Dish mydish);
        void addBranch(Branch mybranch);
        void removeBranch(int id);
        void changeBranch(Branch mybranch);
        int addOrder(Order myorder);
        void removeOrder(int id);
        int changeOrder(Order myorder);
        void addOrderedDish(Ordered_Dish myOrderedDish);
        void removeOrderedDish(int id);
        void removeOrderedDish(int OrderID, int DishID);
        void changeOrderedDish(Ordered_Dish myOrderedDish);
        IEnumerable<Order> getAllOrders();
        IEnumerable<Dish> getAllDishs();
        IEnumerable<Branch> getAllBranches();
        IEnumerable<Ordered_Dish> getAllOrderedDishes();
        double bill(int OrderID);
        List<Dish> MaxPrice(double p);
        List<Dish> CheckDishHechsher(Hechsher h);
        IEnumerable<Ordered_Dish> CheckOrder(Func<Ordered_Dish, bool> predicate = null);
        List<Ordered_Dish> SortDish(int id);
        List<Order> SortDate(DateTime t);
        List<Order> SortAdress(Town adress);
        bool age(int a);//checks that the client is more than 18 aged
        List<Branch> CheckBranchHechsher(Hechsher h);
        Branch getBranch(int id);
        Order getOrder(int id);
        Order getOrder(string name);
        Dish getDish(int id);
        Dish getDishN(string name);
        Ordered_Dish getOrderedDishN(int OrderID, int DishID);
        int getDishID(string p);
        bool existDish(int id);
        bool existOrder(int id);
        bool existOrderedDish(int id);
        bool existBranch(int id);
        bool existOrderedDish(int p1, int p2);
        int getBranchID(string p);
        List<Dish> CheckDishHechsher(Hechsher hechsher, List<Dish> list);
        //List<Order> DateSort(DateTime d);
        double benefits(List<Order> lst);
        List<Branch> CheckBranch(Town town, Hechsher h);
        Dish CountDish(DateTime date);
        Dish CountDish(Town town);
        Dish max(List<Dish> lst);
        Ordered_Dish SelectOrderedDish(Ordered_Dish o);
    }
}


