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
    /// Interaction logic for ShowClient.xaml
    /// </summary>
    public partial class ShowClient : Window
    {
       
        private List<BE.Order> myorders;
        private Order orderChoose;
        private BL.IBL mybl = BL.FactoryBL.getBL();

         public ShowClient()
        {
            InitializeComponent();
            myorders = mybl.getAllOrders().ToList();
            this.DataContext = myorders;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }

        private void dishDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            orderChoose = (Order)dishDataGrid.SelectedItem;
            Update.IsEnabled = true;
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            UpdateCommand wind = new UpdateCommand(orderChoose);
            wind.ShowDialog();
            Close();
        
        }
    }
}
