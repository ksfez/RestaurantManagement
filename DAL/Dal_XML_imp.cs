using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BE;



namespace DAL
{
    internal static class Dal_XML_imp
    {
        internal static XElement orderRoot;
        internal static XElement orderedDishRoot;
        internal static XElement dishRoot;
        internal static XElement branchRoot;
        

        static string dishPath = @"Dish.xml";
        static string orderPath = @"Order.xml";
        static string orderedDishPath = @"OrderedDish.xml";
        static string branchPath = @"Branch.xml";
       

        static Dal_XML_imp()
        {
            if (!File.Exists(dishPath))//if the file dish doesn't exist we create it
                CreateFilesD("Dish", dishPath);
            else
                LoadDishData();//if the file dish exist we open it

            if (!File.Exists(orderPath))//if the file Order doesn't exist we create it
                CreateFilesO("Order", orderPath);
            else
                LoadOrderData();//if the file order exist we open it

            if (!File.Exists(orderedDishPath))//if the file orderedDish doesn't exist we create it
                CreateFilesOD("OrderedDish", orderedDishPath);
            else
                LoadOrderedDishData();//if the file oredered dish exist we open it

            if (!File.Exists(branchPath))//if the file branch doesn't exist we create it
                CreateFilesB("Branch", branchPath);
            else
                LoadBranchData();//if the file branch exist we open it

        }


        //allow to load the file dish
        internal static void LoadDishData()
        {
            LoadData(ref dishRoot, dishPath);
        }

        //allow to load the file order
        internal static void LoadOrderData()
        {
            LoadData(ref orderRoot, orderPath);
        }
        //allow to load the file ordered dish
        internal static void LoadOrderedDishData()
        {
            LoadData(ref orderedDishRoot, orderedDishPath);
        }

        //allow to load the file branch
        internal static void LoadBranchData()
        {
            LoadData(ref branchRoot, branchPath);
        }

        //allow to load a file
        private static void LoadData(ref XElement root, string path)
        {
            root = XElement.Load(path);
        }

        //allows to create a file dish
        private static void CreateFilesD(string label, string dishPath)
        {
            dishRoot = new XElement(label);
            SaveDishData();
        }

        //allow to save the file dish
        internal static void SaveDishData()
        {
            dishRoot.Save(dishPath);
        }

        //allow to create the file order
        private static void CreateFilesO(string label, string orderPath)
        {
            orderRoot = new XElement(label);
            SaveOrderData();
        }

        //allow to save the file order
        internal static void SaveOrderData()
        {
            orderRoot.Save(orderPath);
        }

        //allow to create the file ordered dish
        private static void CreateFilesOD(string label, string orderedDishPath)
        {
            orderedDishRoot = new XElement(label);
            SaveODData();
        }

        //allow to save the file ordered dish
        internal static void SaveODData()
        {
            orderedDishRoot.Save(orderedDishPath);
        }

        //allow to create the file branch
        private static void CreateFilesB(string label, string branchPath)
        {
            branchRoot = new XElement(label);
            SaveBranchData();
        }

        //allow to save the file branch
        internal static void SaveBranchData()
        {
            branchRoot.Save(branchPath);
        }

        //allows to add a dish in the file dish
        internal static void AddDish(XElement dish)
        {
            dishRoot.Add(dish);
            SaveDishData();
        }


        //allows to add an order in the file order
        internal static void AddOrder(XElement order)
        {
            orderRoot.Add(order);
            SaveOrderData();
        }

        //allows to add an orderedDish in the file Ordereddish
        internal static void AddOrderedDish(XElement orderedDish)
        {
            orderedDishRoot.Add(orderedDish);
            SaveODData();
        }

        //allows to add a branch in the file brnch
        internal static void AddBranch(XElement branch)
        {
            branchRoot.Add(branch);
            SaveBranchData();
        }

        //check if a file is empty
        internal static bool IsEmpty(XElement e, string tag)
        {
            return (e.Elements(tag).Count() == 0);
        }

        //allow to transform a dish to a Xelement
        internal static XElement ToXmlDish(this Dish d)
        {
            return new XElement
            (
                "Dish",
                new XElement("Dish_ID", d.Dish_ID),
                new XElement("DishName", d.DishName),
                new XElement("Godel", d.Godel),
                new XElement("Price", d.Price),
                new XElement("RamatHechsher", d.RamatHechsher),
                new XElement("Counter",d.Counter)
            );

        }


        //allow to transform an order to a Xelement
        internal static XElement ToXmlOrder(this Order d)
        {
            return new XElement
            (
                "Order",
                new XElement("Order_ID", d.Order_ID),
                new XElement("OrderName", d.OrderName),
                new XElement("OrderBranch", d.OrderBranch),
                new XElement("Card", d.Card),
                new XElement("Hechsher", d.Hechsher),
                new XElement("Sender", d.Sender),
                new XElement("DeliveryAdress", d.DeliveryAdress),
                new XElement("Date", d.Date),
                new XElement("OrderAdress", d.OrderAdress),
                new XElement("Town", d.Town)

            );

        }


        //allow to transform a branch to a Xelement
        internal static XElement ToXmlBranch(this Branch b)
        {
            return new XElement(
                "Branch",
                new XElement("Branch_ID", b.BranchNum),
                new XElement("BranchName", b.BranchName),
                new XElement("BranchHechsher", b.BranchHechsher),
                new XElement("BranchSenders", b.BranchSenders),
                new XElement("BranchAdress", b.BranchAdress),
                new XElement("Director", b.Director),
                new XElement("Workers", b.Workers),
                new XElement("Phone", b.Phone),
                new XElement("BranchTown", b.BranchTown)
                );
        }


        //allow to transform an ordered dish to a Xelement
        internal static XElement ToXmlOrderedDish(this Ordered_Dish d)
        {
            return new XElement
            (
                "OrderedDish",
                new XElement("Dish_ID", d.Dish_ID),
                new XElement("Order_ID", d.Order_ID),
                new XElement("Quantity", d.Quantity)
            );

        }


        //allow to transform a Xelement to a dish
        internal static Dish ToDish(this XElement e)
        {
            return new Dish
                {
                    Dish_ID = Convert.ToInt32(e.Element("Dish_ID").Value),
                    DishName = (e.Element("DishName").Value),
                    Godel = (DishSize)Enum.Parse(typeof(DishSize), e.Element("Godel").Value),
                    Price = Convert.ToInt32(e.Element("Price").Value),
                    RamatHechsher = (Hechsher)Enum.Parse(typeof(Hechsher), e.Element("Godel").Value)
                };
        }

        //allow to transform a Xelement to an ordered dish
        internal static Ordered_Dish ToOrderedDish(this XElement e)
        {
            return new Ordered_Dish
                 {
                     Order_ID = Convert.ToInt32(e.Element("Order_ID").Value),
                     Dish_ID = Convert.ToInt32(e.Element("Dish_ID").Value),
                     Quantity = Convert.ToInt32(e.Element("Quantity").Value)
                 };
        }

        //allow to transform an order to a XElement
        public static XElement ToXmlOrderID(this Order myOrder)
        {
            return new XElement
           ("OrderID", new XElement("OrderID", myOrder.Order_ID));
        }
    }
}
