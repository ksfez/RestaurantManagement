using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DAL
{
    public class XmlDAL : IDAL
    {

        //allow to add a branch in the file Branch
        public void addBranch(Branch b)
        {
            Dal_XML_imp.LoadBranchData();
            b.BranchNum = Branch_ID() + 1;//fix the id of the branch
            XElement newBranch = b.ToXmlBranch();
            Dal_XML_imp.AddBranch(newBranch);//add the branch b who is a Xelement
        }

        //define the static counter who define the Branch id
        private static int Branch_ID()
        {
            Dal_XML_imp.LoadBranchData();
            if (Dal_XML_imp.IsEmpty(Dal_XML_imp.branchRoot, "Branch"))
            {
                return 0;
            }
            var x = (from e in Dal_XML_imp.branchRoot.Elements("Branch")
                     select e).Max(e => Convert.ToInt32(e.Element("Branch_ID").Value));//check who is the max branchID 
            return x;
        }

        //define the static counter who define the Dish id
        private static int Dish_ID()
        {
            Dal_XML_imp.LoadDishData();
            if (Dal_XML_imp.IsEmpty(Dal_XML_imp.dishRoot, "Dish"))
            {
                return 0;
            }
            var x = (from e in Dal_XML_imp.dishRoot.Elements("Dish")
                     select e).Max(e => Convert.ToInt32(e.Element("Dish_ID").Value));//check who is the max dishID 
            return x;
        }

        //allow to add a dish in the file Dish
        public void addDish(Dish d)
        {
            Dal_XML_imp.LoadDishData();
            d.Dish_ID = Dish_ID() + 1;
            d.Counter = 0;
            XElement newDish = d.ToXmlDish();
            Dal_XML_imp.AddDish(newDish);//add the dish d who is a Xelement
        }

        //allow to add an order in the file Order
        public int addOrder(Order o)
        {
            Dal_XML_imp.LoadOrderData();
            o.Order_ID = Order_ID() + 1;
            XElement newOrder = o.ToXmlOrder();
            Dal_XML_imp.AddOrder(newOrder);//add the order o who is a Xelement
            return o.Order_ID;
        }

        //define the static counter who define the Order id
        private int Order_ID()
        {
            Dal_XML_imp.LoadOrderData();
            if (Dal_XML_imp.IsEmpty(Dal_XML_imp.orderRoot, "Order"))
            {
                return 0;
            }
            var x = (from e in Dal_XML_imp.orderRoot.Elements("Order")
                     select e).Max(e => Convert.ToInt32(e.Element("Order_ID").Value)); //check who is the max OrderID 
            return x;
        }

        //allow to add an ordered Dish in the file OrderedDish
        public void addOrderedDish(Ordered_Dish o)
        {
            Dal_XML_imp.LoadOrderedDishData();
            XElement newOrderedDish = o.ToXmlOrderedDish();
            Dal_XML_imp.AddOrderedDish(newOrderedDish); //add the ordereddish o who is a Xelement
        }

        //allow to update a branch 
        public void changeBranch(Branch b)
        {
            try
            {
                if (!existBranch(b.BranchNum))//if the id doesn't exist 
                    throw new Exception("this Branch doesn't exist");//go to catch
                removeBranch(b); //we remove the branch b
                //Dal_XML_imp.LoadBranchData();
                XElement newBranch = b.ToXmlBranch();
                Dal_XML_imp.AddBranch(newBranch);//add the branch b who is a Xelement
            }
            catch (Exception)
            {
                throw;
            }

        }

        //allow to update a dish
        public void changeDish(Dish d)
        {
            try
            {
                if (!existDish(d.Dish_ID)) //if the id doesn't exist 
                    throw new Exception("this Dish doesn't exist");//go to catch
                removeDish(d);
                //Dal_XML_imp.LoadDishData();
                XElement newDish = d.ToXmlDish();//transform new dish in Xelement
                Dal_XML_imp.AddDish(newDish);//add the dish b who is a Xelement
            }
            catch (Exception)
            {
                throw;
            }
        }

        //allow to update a dish
        public int changeOrder(Order o)
        {
            try
            {
                if (!existOrder(o.Order_ID))//if the id doesn't exist 
                    throw new Exception("this Order doesn't exist");//go to catch
                removeOrder(o);
                //Dal_XML_imp.LoadOrderData();
                XElement newOrder = o.ToXmlOrder();//transform newOrder in Xelement
                Dal_XML_imp.AddOrder(newOrder);//add new order b who is a Xelement
                return o.Order_ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //allow to update a dish
        public void changeOrderedDish(Ordered_Dish o)
        {
            try
            {
                if (!existOrderedDish(o.Order_ID))//if the id doesn't exist 
                    throw new Exception("this Command doesn't exist");//go to catch
                XElement newOrderedDish = o.ToXmlOrderedDish();//transform newOrderedDish in Xelement
                removeOrderedDish(o);
                Dal_XML_imp.AddOrderedDish(newOrderedDish);//add new order b who is a Xelement
                Dal_XML_imp.SaveODData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //check if a branch exist
        public bool existBranch(int id)
        {
            //Dal_XML_imp.LoadBranchData();
            var x = (from e in Dal_XML_imp.branchRoot.Elements("Branch")
                     where Convert.ToInt32(e.Element("Branch_ID").Value) == id
                     select e).FirstOrDefault();//we select the branch with the same id than id
            if (x != null)
                return true;//if there is a branch return true
            else
                return false; //if there is no branch return false
        }

        //check if a dish exist
        public bool existDish(int id)
        {
            //Dal_XML_imp.LoadDishData();
            var x = (from e in Dal_XML_imp.dishRoot.Elements("Dish")
                     where Convert.ToInt32(e.Element("Dish_ID").Value) == id
                     select e).FirstOrDefault();//we select the dish with the same id than id
            if (x != null)
                return true;//if there is a dish return true
            else
                return false; //if there is no dish return false
        }

        //check if an order exist
        public bool existOrder(int id)
        {
           // Dal_XML_imp.LoadOrderData();
            var x = (from e in Dal_XML_imp.orderRoot.Elements("Order")
                     where Convert.ToInt32(e.Element("Order_ID").Value) == id
                     select e).FirstOrDefault();//we select the order with the same id than id
            if (x != null)
                return true;//if there is an order return true
            else
                return false; //if there is no order return false
        }

        //check if a orderedDish exist
        public bool existOrderedDish(int id)
        {
            //Dal_XML_imp.LoadOrderedDishData();
            var x = (from e in Dal_XML_imp.orderedDishRoot.Elements("OrderedDish")
                     where Convert.ToInt32(e.Element("Order_ID").Value) == id
                     select e).FirstOrDefault();//we select the ordereddish with the same order id than id
            if (x != null)
                return true;//if there is an orderedDish return true
            else
                return false; //if there is no ordered dish return false
        }

        //return all the branches
        public IEnumerable<Branch> getAllBranches()
        {
           // Dal_XML_imp.LoadBranchData();
            var v = (from e in Dal_XML_imp.branchRoot.Elements("Branch")
                     select new Branch
                     {
                         BranchNum = Convert.ToInt32(e.Element("Branch_ID").Value),
                         BranchName = e.Element("BranchName").Value,
                         BranchAdress = e.Element("BranchAdress").Value,
                         Director = e.Element("Director").Value,
                         Phone = Convert.ToInt32(e.Element("Phone").Value),
                         BranchSenders = Convert.ToInt32(e.Element("BranchSenders").Value),
                         Workers = Convert.ToInt32(e.Element("Workers").Value),
                         BranchHechsher = (Hechsher)Enum.Parse(typeof(Hechsher), e.Element("BranchHechsher").Value),
                         BranchTown=(Town)Enum.Parse(typeof(Town), e.Element("BranchTown").Value)
                     }).ToList();
            return v;

        }

        //return all the dish
        public IEnumerable<Dish> getAllDishs()
        {
           // Dal_XML_imp.LoadDishData();
            return (from e in Dal_XML_imp.dishRoot.Elements("Dish")
                    select new Dish
                    {
                        Dish_ID = Convert.ToInt32(e.Element("Dish_ID").Value),
                        DishName = e.Element("DishName").Value,
                        Godel = (BE.DishSize)Enum.Parse(typeof(BE.DishSize), e.Element("Godel").Value),
                        Price = Convert.ToDouble(e.Element("Price").Value),
                        RamatHechsher = (BE.Hechsher)Enum.Parse(typeof(BE.Hechsher), e.Element("RamatHechsher").Value),
                        Counter = Convert.ToInt32(e.Element("Counter").Value)
                    }).ToList();
        }

        //return all the orders
        public IEnumerable<Order> getAllOrders()
        {
            //Dal_XML_imp.LoadOrderData();
            var v= (from e in Dal_XML_imp.orderRoot.Elements("Order")
                    select new Order
                    {
                        Order_ID = Convert.ToInt32(e.Element("Order_ID").Value),
                        OrderName = e.Element("OrderName").Value,
                        OrderAdress = e.Element("OrderAdress").Value,
                        DeliveryAdress = e.Element("DeliveryAdress").Value,
                        Card = Convert.ToInt32(e.Element("Card").Value),
                        Sender = Convert.ToInt32(e.Element("Sender").Value),
                        Date = Convert.ToDateTime(e.Element("Date").Value),
                        OrderBranch = Convert.ToInt32(e.Element("OrderBranch").Value),
                        Hechsher = (BE.Hechsher)Enum.Parse(typeof(BE.Hechsher), e.Element("Hechsher").Value),
                        Town = (BE.Town)Enum.Parse(typeof(BE.Town), e.Element("Town").Value)

                    }).ToList();
            return v;
        }

        //allow to get all the orders corresponding to the predicate
        public IEnumerable<Ordered_Dish> getOrders(Func<Ordered_Dish, bool> predicate = null)
        {
            //Dal_XML_imp.LoadOrderedDishData();
            if (predicate == null)
            {
                return (from e in Dal_XML_imp.orderedDishRoot.Elements("OrderedDish")
                        select e.ToOrderedDish()).ToList();//if there is no predicate we return all the orders

            }
            return (from e in Dal_XML_imp.orderedDishRoot.Elements("OrderedDish")
                    let d = e.ToOrderedDish()//abble to do an operation on an element before apply the condition 
                    where predicate(d)
                    select d).ToList();//if there is a predicate we select all the orders corresponding to the predicate
        }

        //allow to remove a branch
        public void removeBranch(Branch b)
        {
            try
            {
                Dal_XML_imp.LoadBranchData();
                if (Dal_XML_imp.IsEmpty(Dal_XML_imp.branchRoot, "Branch"))
                {
                    throw new Exception();// if there is no branch in the file go to catch
                }
                XElement element = getBranchXElement(b.BranchNum);
                if (element == null)
                {
                    throw new Exception();//if there is no id corresponding to the branch id
                }
                element.Remove();//we remove the branch
                Dal_XML_imp.SaveBranchData();//save the file
            }
            catch (Exception)
            {

                throw;
            }

        }

        //select all the branch in the xelement format that corresponding to the id
        private XElement getBranchXElement(int id)
        {
            return (from e in Dal_XML_imp.branchRoot.Elements("Branch")
                    where Convert.ToInt32(e.Element("Branch_ID").Value) == id
                    select e).FirstOrDefault();//select all the branch with the same id than id
        }

        //allow to remove a dish
        public void removeDish(Dish d)
        {

            try
            {
                Dal_XML_imp.LoadDishData();
                if (Dal_XML_imp.IsEmpty(Dal_XML_imp.dishRoot, "Dish"))
                {
                    throw new Exception();// if there is no dish in the file go to catch
                }
                XElement element = getDishXElement(d.Dish_ID);
                if (element == null)
                {
                    throw new Exception();//if there is no id corresponding to the dish id
                }

                element.Remove();//we remove the dish
                Dal_XML_imp.SaveDishData();//save the file
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        //select all the dish in the xelement format that corresponding to the id
        private XElement getDishXElement(int id)
        {
            return (from e in Dal_XML_imp.dishRoot.Elements("Dish")
                    where Convert.ToInt32(e.Element("Dish_ID").Value) == id
                    select e).FirstOrDefault();//select all the dish with the same id than id
        }

        //allow to remove an order
        public void removeOrder(Order o)
        {
            try
            {
                Dal_XML_imp.LoadOrderData();
                if (Dal_XML_imp.IsEmpty(Dal_XML_imp.orderRoot, "Order"))
                {
                    throw new Exception();// if there is no order in the file go to catch
                }
                XElement element = getOrderXElement(o.Order_ID);
                if (element == null)
                {
                    throw new Exception();//if there is no id corresponding to the order id
                }
                element.Remove();//we remove the order
                Dal_XML_imp.SaveOrderData();//save the file
            }
            catch (Exception)
            {

                throw;
            }

        }

        //select all the order in the xelement format that corresponding to the id
        private XElement getOrderXElement(int id)
        {
            return (from e in Dal_XML_imp.orderRoot.Elements("Order")
                    where Convert.ToInt32(e.Element("Order_ID").Value) == id
                    select e).FirstOrDefault();//select all the order with the same id than id
        }

        //allow to remove an ordered dish
        public void removeOrderedDish(Ordered_Dish o)
        {
            try
            {
                Dal_XML_imp.LoadOrderedDishData();
                if (Dal_XML_imp.IsEmpty(Dal_XML_imp.orderedDishRoot, "OrderedDish"))
                {
                    throw new Exception();// if there is no ordered dish in the file go to catch
                }
                XElement element = getOrderedDishXElement(o.Order_ID);
                if (element == null)
                {
                    throw new Exception();//if there is no id corresponding to the order id
                }
                element.Remove();//we remove the ordered dish
                Dal_XML_imp.SaveODData();//save the file
            }
            catch (Exception)
            {

                throw;
            }

        }


        //select all the ordereddish in the xelement format that corresponding to the id
        private XElement getOrderedDishXElement(int id)
        {
            return (from e in Dal_XML_imp.orderedDishRoot.Elements("OrderedDish")
                    where Convert.ToInt32(e.Element("Order_ID").Value) == id
                    select e).FirstOrDefault();//select all the dish with the same id than id
        }

        //return all the ordered dish 
        public IEnumerable<Ordered_Dish> getAllOrderedDishes()
        {
           // Dal_XML_imp.LoadOrderedDishData();
            return (from e in Dal_XML_imp.orderedDishRoot.Elements("OrderedDish")
                    select new Ordered_Dish
                    {
                        Dish_ID = Convert.ToInt32(e.Element("Dish_ID").Value),
                        Order_ID = Convert.ToInt32(e.Element("Order_ID").Value),
                        Quantity= Convert.ToInt32(e.Element("Quantity").Value)
                    }).ToList();
        }
    }
}

