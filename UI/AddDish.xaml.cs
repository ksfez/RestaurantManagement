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
using BL;
using DAL;
using BE;

namespace UI
{
    /// <summary>
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : Window
    {
        private Dish mydish;
        public AddDish()
        {
            InitializeComponent();
            mydish = new Dish();
            this.DataContext = mydish;

            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));//we put values of hechsher in the comboBox
            comboBoxSize.ItemsSource = Enum.GetValues(typeof(BE.DishSize));//we put values of sizes in the comboBox
        }

        public void Add(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            bl.addDish(mydish);//we xall the addDish function
            Window DishWindow = new DishWindow();//go to the main menu
            DishWindow.Show();
            Close();
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window DishWindow = new DishWindow();//go to the main menu
            DishWindow.Show();
            Close();
        }
    }
}
