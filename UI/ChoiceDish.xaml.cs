using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;

namespace UI
{
    /// <summary>
    /// Interaction logic for ChoiceDish.xaml
    /// </summary>
    public partial class ChoiceDish : Window
    {
        private Ordered_Dish o;
        private int neworderid;
        private double maxPrice;
        public ChoiceDish()
        {
            InitializeComponent();
            comboBoxDish.ItemsSource = BL.FactoryBL.getBL().CheckDishHechsher((Hechsher)AddCommand.myOrder.Hechsher).Select(b => b.DishName);

        }

        public ChoiceDish(int neworderid)
        {
            InitializeComponent();
            comboBoxDish.ItemsSource = BL.FactoryBL.getBL().CheckDishHechsher((Hechsher)FactoryBL.getBL().getOrder(neworderid).Hechsher).Select(b => b.DishName);
            this.neworderid = neworderid;

        }

        public ChoiceDish(int neworderid, double maxPrice)
        {
            InitializeComponent();
            this.neworderid = neworderid;
            this.maxPrice = maxPrice;
            List<Dish> list = BL.FactoryBL.getBL().MaxPrice(maxPrice);
            comboBoxDish.ItemsSource = BL.FactoryBL.getBL().CheckDishHechsher((Hechsher)FactoryBL.getBL().getOrder(neworderid).Hechsher, list).Select(b => b.DishName);

        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (!FactoryBL.getBL().existOrderedDish(neworderid))
                FactoryBL.getBL().removeOrder(neworderid);
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void FinishClick(object sender, RoutedEventArgs e)
        {
            o = new Ordered_Dish
            {
                Order_ID = neworderid,
                Dish_ID = BL.FactoryBL.getBL().getDishID((string)comboBoxDish.SelectedValue),
                Quantity = Convert.ToInt32(textBoxQuantity.Text)
            };
            if (o.Quantity != 0)
            {

                if (FactoryBL.getBL().existOrderedDish(o.Order_ID, o.Dish_ID))
                {
                    //var v = (from item in FactoryBL.getBL().getAllOrderedDishes().ToList()
                    //         where (item.Order_ID == o.Order_ID && item.Dish_ID == o.Dish_ID)
                    //         select item).FirstOrDefault();

                    Ordered_Dish v = FactoryBL.getBL().SelectOrderedDish(o);

                    Ordered_Dish myOrderedDish = new Ordered_Dish
                    {
                        Order_ID = o.Order_ID,
                        Dish_ID = o.Dish_ID,
                        Quantity = o.Quantity + v.Quantity
                    };
                    FactoryBL.getBL().removeOrderedDish(v.Order_ID, v.Dish_ID);
                    FactoryBL.getBL().addOrderedDish(myOrderedDish);
                }
                else
                    FactoryBL.getBL().addOrderedDish(o);
            }

            else if (o.Quantity == 0 && (FactoryBL.getBL().CheckOrder(b => b.Order_ID == o.Order_ID).FirstOrDefault()) == null)
            {
                FactoryBL.getBL().removeOrder(o.Order_ID);
            }


            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void AddMoreClick(object sender, RoutedEventArgs e)
        {
            o = new Ordered_Dish
            {
                Order_ID = neworderid,
                Dish_ID = BL.FactoryBL.getBL().getDishID((string)comboBoxDish.SelectedValue),
                Quantity = Convert.ToInt32(textBoxQuantity.Text)
            };

            if (o.Quantity != 0)
            {

                if (FactoryBL.getBL().existOrderedDish(o.Order_ID, o.Dish_ID))
                {
                    //var v = (from item in FactoryBL.getBL().getAllOrderedDishes().ToList()
                    //         where (item.Order_ID == o.Order_ID && item.Dish_ID == o.Dish_ID)
                    //         select item).FirstOrDefault();
                    Ordered_Dish v = FactoryBL.getBL().SelectOrderedDish(o);

                    Ordered_Dish myOrderedDish = new Ordered_Dish
                    {
                        Order_ID = o.Order_ID,
                        Dish_ID = o.Dish_ID,
                        Quantity = o.Quantity + v.Quantity
                    };
                    FactoryBL.getBL().removeOrderedDish(v.Order_ID, v.Dish_ID);
                    FactoryBL.getBL().addOrderedDish(myOrderedDish);
                }
                else
                    FactoryBL.getBL().addOrderedDish(o);
            }

            if (maxPrice != 0)
            {
                Window ChoiceDish = new ChoiceDish(neworderid, maxPrice);//if the client want a maxPrice we go to choice dish by sending two parameters
                ChoiceDish.Show();
                Close();
            }
            else
            {

                Window ChoiceDish1 = new ChoiceDish(o.Order_ID);
                ChoiceDish1.Show();
                Close();
            }
        }
    }
}
