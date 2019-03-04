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
using BE;
using DS;

namespace UI
{
    public partial class DishWindow : Window
    {
        
        public DishWindow()
        {
            InitializeComponent();
           
        }

        private void AddDishClick(object sender, RoutedEventArgs e)
        {
            Window AddDish = new AddDish();
            AddDish.Show();
            this.Close();
        }
        private void DeleteDishClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FactoryBL.getBL().getAllDishs().ToList().FirstOrDefault() != null)
                {
                    Window DeleteDish = new DeleteDish();
                    DeleteDish.Show();
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no dish!", "Dish", MessageBoxButton.OK, MessageBoxImage.Error);
                Window MainWindow = new MainWindow();
                MainWindow.Show();
            }
            this.Close();
        }
        private void UpdateDishClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FactoryBL.getBL().getAllDishs().ToList().FirstOrDefault() != null)
                {
                    Window UpdateDish = new UpdateDish();
                    UpdateDish.Show();
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no dish!", "Dish", MessageBoxButton.OK, MessageBoxImage.Error);
                Window MainWindow = new MainWindow();
                MainWindow.Show();
            }
            this.Close();
        }
        private void GetAllDishClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Dish> alldish;
                alldish = FactoryBL.getBL().getAllDishs().ToList();
                if ( alldish== null)
                {
                    throw new Exception();
                }
                else
                {
                    Window ShowDishes = new ShowDishes();
                    ShowDishes.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is no dish!", "Dish", MessageBoxButton.OK, MessageBoxImage.Error);
                Window MainWindow = new MainWindow();
                MainWindow.Show();
            }
            this.Close();
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window MainWindow = new MainWindow();
            MainWindow.Show();
            Close();
        }
    }
}
