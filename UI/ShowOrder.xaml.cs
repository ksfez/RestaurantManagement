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

namespace UI
{
    /// <summary>
    /// Interaction logic for ShowOrder.xaml
    /// </summary>
    public partial class ShowOrder : Window
    {
        List<Ordered_Dish> myOrderedDish;
        private BL.IBL mybl = BL.FactoryBL.getBL();
        public ShowOrder()
        {
            InitializeComponent();
            comboBoxOrder.ItemsSource = BL.FactoryBL.getBL().getAllOrders().Select(b => b.Order_ID);
        }


        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void comboBoxOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myOrderedDish = mybl.CheckOrder(b => b.Order_ID == (int)comboBoxOrder.SelectedItem).ToList();
            this.DataContext = myOrderedDish;
            //foreach (Ordered_Dish o in myOrderedDish)
            //    NameColumn. = mybl.getDish(o.Dish_ID);
            textBlockBill.Text = (BL.FactoryBL.getBL().bill((int)comboBoxOrder.SelectedItem)).ToString();
        }
    }
}
