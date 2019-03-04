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
using BE;
using DAL;

namespace UI
{
    /// <summary>
    /// Interaction logic for DeleteOrderedDish.xaml
    /// </summary>
    public partial class DeleteCommand : Window
    {
        public DeleteCommand()
        {
            InitializeComponent();
            comboBoxID.ItemsSource = BL.FactoryBL.getBL().getAllOrders().Select(b => b.Order_ID);
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            bl.removeOrderedDish((int)comboBoxID.SelectedItem);//remove ordered dish
            bl.removeOrder((int)comboBoxID.SelectedItem);//remove order
            Window Command = new CommandWindow();
            Command.Show();
            Close();
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window Command = new CommandWindow();
            Command.Show();
            Close();
        }
       
    }
}
