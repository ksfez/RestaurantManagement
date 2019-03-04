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
    /// Interaction logic for PodiumAdress.xaml
    /// </summary>
    public partial class PodiumAdress : Window
    {
        public PodiumAdress()
        {
            InitializeComponent();
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));
        }
        
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Window StatisticWindow = new StatisticWindow();
            StatisticWindow.Show();//go to main menu
            Close();
        }
        private void ComboBoxTown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (FactoryBL.getBL().CountDish((Town)ComboBoxTown.SelectedItem) == null)
                    throw new Exception();
                TextBlockWinner.Text = FactoryBL.getBL().CountDish((Town)ComboBoxTown.SelectedItem).DishName;
            }
            catch (Exception)
            {
                MessageBox.Show("There is no dish ordered in this town!", "Best Dish", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
