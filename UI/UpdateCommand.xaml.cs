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
using BL;
using DAL;
using BE;

namespace UI
{
    public partial class UpdateCommand : Window
    {
        Ordered_Dish myOrderedDish;
        public UpdateCommand()
        {
            InitializeComponent();
            myOrderedDish = new Ordered_Dish();
            this.DataContext = myOrderedDish;
            comboBoxOrder.ItemsSource = BL.FactoryBL.getBL().getAllOrders().Select(b => b.Order_ID);
        }

        public UpdateCommand(Order orderChoose)
        {
            InitializeComponent();
            myOrderedDish = new Ordered_Dish();
            myOrderedDish.Order_ID = orderChoose.Order_ID;
            this.DataContext = myOrderedDish;
            comboBoxOrder.ItemsSource = BL.FactoryBL.getBL().getAllOrders().Select(b => b.Order_ID);
            comboBoxOrder.SelectedValue = orderChoose.Order_ID;
            comboBoxDish.ItemsSource = BL.FactoryBL.getBL().CheckOrder(b=>b.Order_ID==(orderChoose.Order_ID)).Select(b=>FactoryBL.getBL().getDish(b.Dish_ID).DishName);

        }
        private void Update(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            
            myOrderedDish.Dish_ID = BL.FactoryBL.getBL().getDishID((string)comboBoxDish.SelectedValue);
            if (myOrderedDish.Quantity != 0)
                bl.changeOrderedDish(myOrderedDish);
            else
                bl.removeOrderedDish(myOrderedDish.Order_ID,myOrderedDish.Dish_ID);
            if (myOrderedDish.Quantity == 0 && (FactoryBL.getBL().CheckOrder(b => b.Order_ID == myOrderedDish.Order_ID).FirstOrDefault()) == null)
            {
                FactoryBL.getBL().removeOrder(myOrderedDish.Order_ID);
            }

            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void comboBoxOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxDish.ItemsSource = BL.FactoryBL.getBL().CheckOrder(b=>b.Order_ID==(int)(comboBoxOrder.SelectedItem)).Select(b=>FactoryBL.getBL().getDish(b.Dish_ID).DishName);

        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void comboBoxDish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Dishid=FactoryBL.getBL().getDishN((string)comboBoxDish.SelectedItem).Dish_ID;
            int Orderid=(int)(comboBoxOrder.SelectedItem);
            textBoxQuantity.Text = FactoryBL.getBL().getOrderedDishN(Orderid, Dishid).Quantity.ToString();
        }
    }
}
