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
    /// <summary>
    /// Interaction logic for DeleteDish.xaml
    /// </summary>
    public partial class DeleteDish : Window
    {
        public DeleteDish()
        {
            InitializeComponent();
            ComboDishID.ItemsSource = BL.FactoryBL.getBL().getAllDishs().Select(b => b.Dish_ID);
        }
        public void DeleteClick(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            bl.removeDish((int)ComboDishID.SelectedItem);//remove dish

            Window DishWindow = new DishWindow();
            DishWindow.Show();
            Close();
        }
        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window DishWindow = new DishWindow();
            DishWindow.Show();
            Close();
        }
    }

}
