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
    /// Interaction logic for PodiumDate.xaml
    /// </summary>
    public partial class PodiumDate : Window
    {
        public PodiumDate()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window StatisticWindow = new StatisticWindow();
            StatisticWindow.Show();//go to main menu
            Close();
        }
        private void DatePicker_changed(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (FactoryBL.getBL().CountDish((DateTime)DatePicker.SelectedDate) == null)
                    throw new Exception();
                TextBlockWinner.Text = FactoryBL.getBL().CountDish((DateTime)DatePicker.SelectedDate).DishName;
            }
            catch (Exception)
            {
                MessageBox.Show("There is no dish ordered at this date", "Best Dish", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
