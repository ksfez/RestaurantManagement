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
    /// Interaction logic for ShowDishes.xaml
    /// </summary>
    public partial class ShowDishes : Window
    {
        private List<BE.Dish> mydishes;
        private Dish plat_choisi;
        private BL.IBL mybl = BL.FactoryBL.getBL();

        public ShowDishes()
        {
            InitializeComponent();
            mydishes = mybl.getAllDishs().ToList();
            this.DataContext = mydishes;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window DishWindow = new DishWindow();
            DishWindow.Show();
            Close();
        }

        private void dishDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            plat_choisi = (Dish)dishDataGrid.SelectedItem;
            idkun.IsEnabled = true;
        }

        private void idkun_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDish wind = new UpdateDish(plat_choisi);
            wind.ShowDialog();
            Close();
        }
    }
}
