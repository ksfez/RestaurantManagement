using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;


namespace BL
{
    public class ListBl : IBL //this class define the interface IBL
    {
        //the function allows to add a new dish 
        public void addDish(Dish mydish)
        {
            //mydish.DishName = mydish.DishName;
            IDAL mydal = FactoryDal.getDal();
            mydal.addDish(mydish);//we call the DAL layer
        }

        //the function allows to remove a dish 
        public void removeDish(int id)
        {

            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (!mydal.existDish(id))
                {
                    throw new Exception();//if the dish doesn't exist we go to the catch
                }
                else
                {

                    var v = from item in FactoryDal.getDal().getAllDishs().ToList()
                            where item.Dish_ID == id //we see which dishId correspond to the id that we want to remove
                            select item;
                    foreach (var item in v)
                        mydal.removeDish(item);//we call the DAL layer
                }
            }
            catch (Exception)
            {

            }

        }

        //the function update to remove a dish 
        public void changeDish(Dish mydish)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existDish(mydish.Dish_ID))//we check if the dish exist
                {
                    Dish d = new Dish //we define a new Dish with the parameters of mydish
                    {
                        Dish_ID = mydish.Dish_ID,
                        DishName = mydish.DishName,
                        Godel = mydish.Godel,
                        Price = mydish.Price,
                        RamatHechsher = mydish.RamatHechsher
                    };
                    mydal.changeDish(d);//we call the DAL layer
                }
                else throw new Exception();//if the dish doesn't exist we go to the catch
            }
            catch (Exception)
            {
            }
        }

        //the function allows to add a branch 
        public void addBranch(Branch mybranch)
        {
            Branch b = new Branch//we creates a new branch with the parameters of mybranch
            {
                BranchName = mybranch.BranchName,
                BranchAdress = mybranch.BranchAdress,
                BranchSenders = mybranch.BranchSenders,
                BranchHechsher = mybranch.BranchHechsher,
                Director = mybranch.Director,
                Phone = mybranch.Phone,
                Workers = mybranch.Workers,
                BranchTown = mybranch.BranchTown
            };

            IDAL mydal = FactoryDal.getDal();
            mydal.addBranch(b);//we call the DAL layer
        }

        //the function allows to remove a branch 
        public void removeBranch(int id)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existBranch(id))//we check if the branch exists
                {
                    var v = from item in FactoryDal.getDal().getAllBranches().ToList()//we pass on all the branches
                            where item.BranchNum == id
                            select item;//we select the branch that has the same branchId that id
                    foreach (var item in v)
                        mydal.removeBranch(item);//we call the DAL layer
                }
                else throw new Exception();//we go to the catch
            }
            catch (Exception)
            {
            }
        }

        //the function allows to update a branch 
        public void changeBranch(Branch mybranch)
        {

            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existBranch(mybranch.BranchNum))//we check if the branch exists
                {
                    Branch b = new Branch//we creates a new branch with the parameters of mybranch
                    {
                        BranchNum = mybranch.BranchNum,
                        BranchName = mybranch.BranchName,
                        BranchAdress = mybranch.BranchAdress,
                        BranchSenders = mybranch.BranchSenders,
                        BranchHechsher = mybranch.BranchHechsher,
                        Director = mybranch.Director,
                        Phone = mybranch.Phone,
                        Workers = mybranch.Workers,
                        BranchTown = mybranch.BranchTown
                    };
                    mydal.changeBranch(b);//we call the DAL layer
                }
                else throw new Exception();//we go to the catch
            }
            catch (Exception)
            {
            }
        }

        //the function allows to add an order
        public int addOrder(Order myorder)
        {
            Order o = new Order //we creates a new order with the parameters of myorder
            {
                OrderAdress = myorder.OrderAdress,
                Card = myorder.Card,
                Date = myorder.Date,
                DeliveryAdress = myorder.DeliveryAdress,
                OrderBranch = myorder.OrderBranch,
                OrderName = myorder.OrderName,
                Hechsher = myorder.Hechsher,
                Town = myorder.Town
            };
            IDAL mydal = FactoryDal.getDal();
            return (mydal.addOrder(o));//we call the DAL layer
        }

        //the function allows to remove an order
        public void removeOrder(int id)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existOrder(id))//we check if the order exists
                {
                    var v = from item in FactoryDal.getDal().getAllOrders().ToList()//we pass on all the orders
                            where item.Order_ID == id
                            select item;//we select all the order that the orderId==id
                    foreach (var item in v)
                        mydal.removeOrder(item);//we call the DAL layer
                }
                else throw new Exception();
            }
            catch (Exception)
            { }
        }

        //the function allows to update an order
        public int changeOrder(Order myorder)
        {
            IDAL mydal = FactoryDal.getDal();
            if (mydal.existOrder(myorder.Order_ID)) //we check if the order exists
            {
                Order o = new Order //we creates a new order with the parameters of myorder
                {
                    Order_ID = myorder.Order_ID,
                    OrderAdress = myorder.OrderAdress,
                    OrderBranch = myorder.OrderBranch,
                    OrderName = myorder.OrderName,
                    Card = myorder.Card,
                    Date = myorder.Date,
                    DeliveryAdress = myorder.DeliveryAdress,
                    Town = myorder.Town
                };

                return (mydal.changeOrder(o));//we call the DAL layer
            }
            else
                return 0;

        }


        //the function allows to add an ordered-Dish
        public void addOrderedDish(Ordered_Dish myOrderedDish)
        {
            Ordered_Dish o = new Ordered_Dish //we creates a new order with the parameters of myorderedish
            {
                Order_ID = myOrderedDish.Order_ID,
                Dish_ID = myOrderedDish.Dish_ID,
                Quantity = myOrderedDish.Quantity,
            };
            IDAL mydal = FactoryDal.getDal();
            mydal.addOrderedDish(o);//we call the DAL layer
        }

        //the function allows to remove all ordered-Dish of an order
        public void removeOrderedDish(int id)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existOrderedDish(id))//we check if the orderedDish exists
                {
                    var v = (from item in FactoryDal.getDal().getAllOrderedDishes().ToList()//we pass on all the orderedDish
                             where item.Order_ID == id
                             select item).ToList();//we select all the order that the orderId==id
                    foreach (Ordered_Dish item in v)
                        mydal.removeOrderedDish(item);//we call the DAL layer
                }
                else throw new Exception();//we go to the catch
            }
            catch (Exception)
            { }
        }

        //the function allows to update an ordered-Dish
        public void changeOrderedDish(Ordered_Dish myOrderedDish)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (mydal.existOrderedDish(myOrderedDish.Order_ID))//we check if the orderedDish exists
                {
                    Ordered_Dish o = new Ordered_Dish //we creates a new order with the parameters of myorderedish
                    {
                        Order_ID = myOrderedDish.Order_ID,
                        Dish_ID = myOrderedDish.Dish_ID,
                        Quantity = myOrderedDish.Quantity,
                    };
                    mydal.changeOrderedDish(o);//we call the DAL layer
                }
                else throw new Exception();//go to catch
            }
            catch (Exception)
            {
            }
        }

        //the function allows to get an order based on the id send by the user
        public Order getOrder(int id)
        {
            return (from item in FactoryDal.getDal().getAllOrders().ToList()
                    where item.Order_ID == id
                    select item).FirstOrDefault();//we select all the order that the orderId==id
        }

        public Order getOrder(string name)
        {
            return (from item in FactoryDal.getDal().getAllOrders().ToList()
                    where item.OrderName == name
                    select item).FirstOrDefault();
        }

        //the function allows to get all the ordered-Dish
        public IEnumerable<Ordered_Dish> getAllOrderedDishes()
        {
            return FactoryDal.getDal().getAllOrderedDishes();//we call the DAL layer

        }

        //the function allows to get all the order
        public IEnumerable<Order> getAllOrders()
        {
            return FactoryDal.getDal().getAllOrders();//we call the DAL layer

        }

        //the function allows to get all the dish
        public IEnumerable<Dish> getAllDishs()
        {
            return FactoryDal.getDal().getAllDishs();//we call the DAL layer
        }

        //the function allows to get all the branches
        public IEnumerable<Branch> getAllBranches()
        {
            return FactoryDal.getDal().getAllBranches();//we call the DAL layer
        }

        //the function calculate the bill of an order
        public double bill(int OrderID)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (!mydal.existOrder(OrderID))//check if the order exists
                    throw new Exception("order doesn't exist!");//go to catch
                var v1 = (from item in getAllOrderedDishes().ToList()
                          where OrderID == item.Order_ID//we select all the order that the orderId==id
                          select item).ToList();

                double sum = 0;
                foreach (Ordered_Dish item1 in v1)//in the list of ordered dish that we receive 
                {
                    var v2 = (from item in getAllDishs().ToList()
                              where item1.Dish_ID == item.Dish_ID//we check which dishes appears in this list
                              select item).ToList();
                    foreach (Dish item2 in v2)
                    {
                        sum += item1.Quantity * item2.Price;//calculate the bill
                    }
                }
                return sum;//returns the bill of an order
            }
            catch (Exception)
            {
                throw null;
            }

        }

        //the function allows to get all the dish that they are little than p
        public List<Dish> MaxPrice(double p)
        {
            try
            {
                if (FactoryDal.getDal().getAllDishs().ToList() == null)//if there is no dish
                    throw new Exception("there is no dish!");//go to catch
                var v = (from item in FactoryDal.getDal().getAllDishs().ToList()
                         where item.Price < p
                         select item).ToList();//we return all the dishes that their price are inferior than p
                return v;
            }
            catch (Exception)
            {
                throw null;
            }
        }
        //the function check all the dish and get all the dish that the hescher is the same that h
        public List<Dish> CheckDishHechsher(Hechsher h)
        {
            var v = (from item in FactoryDal.getDal().getAllDishs().ToList()
                     where item.RamatHechsher == h
                     select item).ToList();//we select all the dishes which hechsher equal to h
            return v;

        }
        //the function check the dish in the list send by the user and get all the dish that the hescher is the same that h
        public List<Dish> CheckDishHechsher(Hechsher h, List<Dish> lst)
        {
            var v = (from item in lst//in the specific list of dishes
                     where item.RamatHechsher == h
                     select item).ToList();//we select all the dishes which hechsher equal to h
            return v;
        }

        //the function get all the ordered-dish that correspond to the predicate sent
        public IEnumerable<Ordered_Dish> CheckOrder(Func<Ordered_Dish, bool> predicate = null)
        {
            return FactoryDal.getDal().getOrders(predicate);//we call the DAL layer
        }

        //sort by Order_ID all the orderedDish
        public List<Ordered_Dish> SortDish(int id)
        {
            if (getAllOrderedDishes().ToList() == null)//if there is no orderedDish
                throw new Exception("ordered dish doesn't exist!");//go to catch
            var v = from item in FactoryDal.getDal().getAllOrderedDishes().ToList()
                    group item by item.Order_ID into g
                    select new { OrderID = g.Key, OrderGroup = g };//we select all the ordered dish which are in the same order
            List<Ordered_Dish> lst = new List<Ordered_Dish>();
            foreach (var item in v)
                if (item.OrderID == id)
                    foreach (Ordered_Dish o in item.OrderGroup)
                        lst.Add(o);//we do a list with all the ordered dish that the order with this "id" ordered
            return lst;
        }

        public Dish CountDish(Town town)
        {

            if (getAllOrderedDishes().ToList() == null)//if there is no orderedDish
                throw new Exception("ordered dish doesn't exist!");//go to catch
            List<Order> lst = SortAdress(town);
            List<Ordered_Dish> lst1 = new List<Ordered_Dish>();
            List<Dish> lst2 = new List<Dish>();
            var v = from item in lst
                    from item2 in getAllOrderedDishes()
                    where item.Order_ID == item2.Order_ID
                    select item2; //select the ordered dish with the same order id
            foreach (var item in v)
                lst1.Add(item);
            foreach (Ordered_Dish item in lst1)
            {
                Dish dish = getDish(item.Dish_ID);
                var v1 = (from item2 in lst2
                          where item2.Dish_ID == item.Dish_ID
                          select item2);
                if (lst2.Exists(b => b.Dish_ID == item.Dish_ID))
                {
                    foreach (var item3 in v1)
                        dish = item3;

                }
                Dish d = new Dish //we define a new Dish with the parameters of mydish
                {
                    Dish_ID = dish.Dish_ID,
                    DishName = dish.DishName,
                    Godel = dish.Godel,
                    Price = dish.Price,
                    RamatHechsher = dish.RamatHechsher,
                    Counter = dish.Counter + item.Quantity
                };

                lst2.Add(d);
                lst2.RemoveAll(b => b.Dish_ID == item.Dish_ID && b.Counter <= dish.Counter);
            }
            Dish M = max(lst2);
            foreach (Dish item in getAllDishs())
                item.Counter = 0;
            return M;
        }

        public Dish CountDish(DateTime date)
        {

            if (getAllOrderedDishes().ToList() == null)//if there is no orderedDish
                throw new Exception("ordered dish doesn't exist!");//go to catch
            List<Order> lst = SortDate(date);
            List<Ordered_Dish> lst1 = new List<Ordered_Dish>();
            List<Dish> lst2 = new List<Dish>();
            var v = from item in lst
                    from item2 in getAllOrderedDishes()
                    where item.Order_ID == item2.Order_ID
                    select item2;
            foreach (var item in v)
                lst1.Add(item);
            foreach (Ordered_Dish item in lst1)
            {
                Dish dish = getDish(item.Dish_ID);
                var v1 = (from item2 in lst2
                          where item2.Dish_ID == item.Dish_ID
                          select item2);
                if (lst2.Exists(b => b.Dish_ID == item.Dish_ID))
                {
                    foreach (var item3 in v1)
                        dish = item3;

                }
                Dish d = new Dish //we define a new Dish with the parameters of mydish
                    {
                        Dish_ID = dish.Dish_ID,
                        DishName = dish.DishName,
                        Godel = dish.Godel,
                        Price = dish.Price,
                        RamatHechsher = dish.RamatHechsher,
                        Counter = dish.Counter + item.Quantity
                    };
                // FactoryDal.getDal().changeDish(d);//we call the DAL layer

                lst2.Add(d);
                lst2.RemoveAll(b => b.Dish_ID == item.Dish_ID && b.Counter <= dish.Counter);
            }
            Dish M = max(lst2);
            foreach (Dish item in getAllDishs())
                item.Counter = 0;
            return M;
        }

        public Dish max(List<Dish> lst)
        {
            if (lst == null)
                return null;
            Dish max = lst.First();
            for (int i = 0; lst.ElementAt(i) != lst.Last(); i++)
            {
                if (max.Counter < lst.ElementAt(i).Counter)
                    max = lst.ElementAt(i);
            }
            if (max.Counter < lst.Last().Counter)
                max = lst.Last();
            return max;
        }

        //sort by Date all the order and get all the order that correspond to the date sent
        public List<Order> SortDate(DateTime d)
        {
            var v = (from item in getAllOrders().ToList()
                     group item by item.Date into g
                     select new { date = g.Key, orderGroup = g });//we do groups of orders according to the orders do in the similar date
            List<Order> lst = new List<Order>();
            foreach (var item in v)
                if (item.date == d)
                    foreach (Order o in item.orderGroup)
                        lst.Add(o);//we do a list with all the order which did in the same date
            return lst;
        }

        //sort by adress all the order and get all the order that correspond to the adress sent
        public List<Order> SortAdress(Town adress)
        {
            var v = (from item in getAllOrders().ToList()
                     group item by item.Town into g
                     select new { town = g.Key, orderGroup = g });//we do groups of orders according to the orders do in the similar town
            List<Order> lst = new List<Order>();
            foreach (var item in v)
            {
                if (item.town == adress)
                    foreach (Order o in item.orderGroup)
                        lst.Add(o);//we do a list with all the order which did in the same town
            }
            //var v1 = (from item1 in v
            //          where item1.town == adress
            //          select item1.orderGroup);
            //foreach (Order o in v1)
            //lst.Add(o);//we do a list with all the order which did in the same town

            return lst;
        }

        //the function calculate all the benefits of the orders sent
        public double benefits(List<Order> lst)
        {
            double benefit = 0;
            foreach (Order item in lst)
            {
                benefit += bill(item.Order_ID);//we sum the bill of all the order of a specific list
            }
            return benefit;
        }

        public bool age(int a)//checks that the client is more than 18 aged
        {
            if (a >= 18)
                return true;
            else
                return false;
        }

        //check if branch correspond to the hechsher h and return all the branches that correspond to the hechsher h
        public List<Branch> CheckBranchHechsher(Hechsher h)
        {
            var v = (from item in FactoryDal.getDal().getAllBranches().ToList()
                     where item.BranchHechsher == h
                     select item).ToList();//we select all the branches which hechsher equal to h
            return v;
        }
        public List<Branch> CheckBranch(Town town, Hechsher h)
        {
            var v = (from item in FactoryDal.getDal().getAllBranches().ToList()
                     where item.BranchHechsher == h && item.BranchTown == town
                     select item).ToList();//we select all the branches which hechsher equal to h and do in the town equal to the parameter town
            return v;
        }

        //return all dishes that correspond to the id sent
        public Dish getDish(int id)
        {
            return (from item in FactoryDal.getDal().getAllDishs().ToList()
                    where item.Dish_ID == id
                    select item).FirstOrDefault();//we select the dishes with the sme id than the parameter id
        }

        //return all branches that correspond to the id sent
        public Branch getBranch(int id)
        {
            return (from item in FactoryDal.getDal().getAllBranches().ToList()
                    where item.BranchNum == id
                    select item).FirstOrDefault();//we select  the branches with the sme id than the parameter id
        }

        //the function allow to get the id of a dish when the name of the dish is sending
        public int getDishID(string name)
        {
            return (from item in FactoryDal.getDal().getAllDishs().ToList()
                    where item.DishName == name
                    select item.Dish_ID).FirstOrDefault();//we return the id of a dish according to its name
        }

        //check if a dish with a specific id exist
        public bool existDish(int id)
        {
            return FactoryDal.getDal().existDish(id);//we call the DAL layer
        }
        //check if an order with a specific id exist
        public bool existOrder(int id)
        {
            return FactoryDal.getDal().existOrder(id);//we call the DAL layer
        }
        //check if an ordered dish with a specific id exist
        public bool existOrderedDish(int id)
        {
            return FactoryDal.getDal().existOrderedDish(id);//we call the DAL layer
        }

        //check if a branch with a specific id exist
        public bool existBranch(int id)
        {
            return FactoryDal.getDal().existBranch(id);//we call the DAL layer
        }

        ////check if an ordered dish with a specific Orderid and DishID exist
        public bool existOrderedDish(int OrderID, int DishID)
        {
            var v = (from item in FactoryDal.getDal().getAllOrderedDishes().ToList()
                     where (item.Order_ID == OrderID && item.Dish_ID == DishID)
                     select item).FirstOrDefault();//select all the ordered dish with the same orderId than the parameter OrderID and the same dishId than the parameter dishID
            if (v != null)
                return true;
            else
                return false;
        }
        //the function allow to remove an ordered dish
        public void removeOrderedDish(int OrderID, int DishID)
        {
            try
            {
                IDAL mydal = FactoryDal.getDal();
                if (existOrderedDish(OrderID, DishID))
                {
                    var v = (from item in FactoryDal.getDal().getAllOrderedDishes().ToList()
                             where (item.Order_ID == OrderID && item.Dish_ID == DishID)
                             select item);//select all the ordered dish with the same orderId than the parameter OrderID and the same dishId than the parameter dishID

                    foreach (var item in v)
                        mydal.removeOrderedDish(item);//we call the DAL layer
                }
                else throw new Exception();
            }
            catch (Exception)
            { }
        }

        //the function allows to get a branch id of a branch when the name of this branch was sent
        public int getBranchID(string name)
        {
            return (from item in FactoryDal.getDal().getAllBranches().ToList()
                    where item.BranchName == name
                    select item.BranchNum).FirstOrDefault();//return the id of branches with the same name than the parameter name
        }

        public Ordered_Dish SelectOrderedDish(Ordered_Dish o)
        {
            var v = (from item in FactoryBL.getBL().getAllOrderedDishes().ToList()
                     where (item.Order_ID == o.Order_ID && item.Dish_ID == o.Dish_ID)
                     select item).FirstOrDefault();
            return v;
        }

        public Dish getDishN(string name)
        {
            return (from item in FactoryDal.getDal().getAllDishs().ToList()
                    where item.DishName == name
                    select item).FirstOrDefault();//we select the dishes with the sme id than the parameter id
        }
        public Ordered_Dish getOrderedDishN(int OrderID, int DishID)
        {
            var v = (from item in FactoryDal.getDal().getAllOrderedDishes().ToList()
                     where (item.Order_ID == OrderID && item.Dish_ID == DishID)
                     select item).FirstOrDefault();//select all the ordered dish with the same orderId than the parameter OrderID and the same dishId than the parameter dishID

            return v;
        }
    }

}

