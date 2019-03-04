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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DS;
using BL;
using BE;
using DAL;

namespace UI
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class CommandWindow : Window
    {

        private IBL mybl;
        public CommandWindow()
        {
            InitializeComponent();
            mybl = FactoryBL.getBL();
        }

        private void AddCommandClick(object sender, RoutedEventArgs e)
        {
            Window Client = new Client();
            Client.Show();
            this.Close();
        }
        private void DeleteCommandClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mybl.getAllOrders().FirstOrDefault() != null)
                {
                    Window DeleteCommand = new DeleteCommand();
                    DeleteCommand.Show();
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no order!", "Order", MessageBoxButton.OK, MessageBoxImage.Error);
                Window CommandWindow = new CommandWindow();
                CommandWindow.Show();

            }
            this.Close();
        }
        private void UpdateCommandClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mybl.getAllOrders().FirstOrDefault() == null)
                   //if (Dal_XML_imp.IsEmpty(Dal_XML_imp.orderRoot, "Order").FirstOrDefault() == null)
                    throw new Exception();
                else 
                {
                    Window UpdateCommand = new UpdateCommand();
                    UpdateCommand.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is no order!", "Order", MessageBoxButton.OK, MessageBoxImage.Error);
                Window CommandWindow = new CommandWindow();
                CommandWindow.Show();
            }
            this.Close();
        }

        private void ShowOrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mybl.getAllOrders().FirstOrDefault() == null)
                    throw new Exception();
                else
                {
                    Window ShowOrder = new ShowOrder();
                    ShowOrder.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("There is no order!", "Order", MessageBoxButton.OK, MessageBoxImage.Error);
                Window CommandWindow = new CommandWindow();
                CommandWindow.Show();
            }
            this.Close();

        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }

        private void ShowCLick(object sender, System.Windows.RoutedEventArgs e)
        {
            Window showClient= new ShowClient();
            showClient.Show();
            Close();
        }
    }
}
