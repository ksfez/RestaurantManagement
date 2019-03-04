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

namespace UI
{
    /// <summary>
    /// Interaction logic for DateStatistic.xaml
    /// </summary>
    public partial class DateStatistic : Window
    {
        public DateStatistic()
        {
            InitializeComponent();
        }
        void OKClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(DatePicker.SelectedDate==null)
                    throw new Exception();
                string msg = "On this date the benefits are: ";
                List<Order> lst = new List<Order>();
                lst = FactoryBL.getBL().SortDate((DateTime)DatePicker.SelectedDate);
                double ben = FactoryBL.getBL().benefits(lst);
                msg += ben.ToString();
                msg += " shekel";
                MessageBox.Show(msg, "Statistic", MessageBoxButton.OK, MessageBoxImage.Information);//send a message with the benefits
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a date", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);//if we don't enter a date send a message
            }
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window Statistic = new StatisticWindow();
            Statistic.Show();
            Close();
        }
    }
}
