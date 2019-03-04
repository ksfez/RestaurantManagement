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
    /// Interaction logic for AdressStatistic.xaml
    /// </summary>
    public partial class AdressStatistic : Window
    {
        public AdressStatistic()
        {
            InitializeComponent();
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));//we put values of town in the comboBox
        }

        void OKClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxTown.SelectedItem == null)
                    throw new Exception();
                string msg = "On this town the benefits are: ";
                List<Order> lst = new List<Order>();
                lst = FactoryBL.getBL().SortAdress((Town)ComboBoxTown.SelectedItem);//we create a new list with Order make in the town choose by the user
                double ben = FactoryBL.getBL().benefits(lst);//we calculate the benefits of this orders
                msg += ben.ToString();
                msg += " shekel";
                MessageBox.Show(msg, "Statistic", MessageBoxButton.OK, MessageBoxImage.Information);//we show to the user the benefits doing in this town
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a town", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window StatisticWindow = new StatisticWindow();
            StatisticWindow.Show();//go to main menu
            Close();
        }
    }
}
