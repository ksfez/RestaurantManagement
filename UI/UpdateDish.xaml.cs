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
using DAL;
using BL;

namespace UI
{
    /// <summary>
    /// Interaction logic for UpdateDishWindow.xaml
    /// </summary>
    public partial class UpdateDish : Window
    {
        Dish mydish;
        private List<BE.Dish> alldishes;
        
        public UpdateDish()
        {
            InitializeComponent();
            alldishes = BL.FactoryBL.getBL().getAllDishs().ToList();
            this.DataContext = alldishes;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));
            comboBoxSize.ItemsSource = Enum.GetValues(typeof(BE.DishSize));
            comboBoxDishID.ItemsSource = alldishes.Select(d => d.Dish_ID);
                
        }

        public UpdateDish(Dish plat_choisi)
        {
            InitializeComponent();
            alldishes = BL.FactoryBL.getBL().getAllDishs().ToList();
            this.DataContext = alldishes;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));
            comboBoxSize.ItemsSource = Enum.GetValues(typeof(BE.DishSize));
            comboBoxDishID.ItemsSource = alldishes.Select(d => d.Dish_ID);
            // TODO: Complete member initialization
            
            
            mydish = plat_choisi; //BL.FactoryBL.getBL().getDish(id);
            comboBoxDishID.SelectedValue = mydish.Dish_ID;
            textBoxDishName.Text = mydish.DishName;
            textBoxPrice.Text = mydish.Price.ToString();
            comboBoxSize.SelectedValue = mydish.Godel;
            comboBoxHechsher.SelectedValue = mydish.RamatHechsher;
 
        }


        public void UpdateClick(object sender, RoutedEventArgs e)
        {


            if (textBoxDishName.Text != "")
            {
                try
                {
                    mydish.DishName = textBoxDishName.Text;
                    mydish.Price = Convert.ToDouble(textBoxPrice.Text);
                    mydish.Godel = (BE.DishSize)comboBoxSize.SelectedValue;
                    mydish.RamatHechsher = (BE.Hechsher)comboBoxHechsher.SelectedValue;

                    IBL bl = FactoryBL.getBL();
                    bl.changeDish(mydish);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                Window DishWindow = new DishWindow();
                DishWindow.Show();
                Close();
            }
        }

        private void dish_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (int)comboBoxDishID.SelectedItem;
            mydish = BL.FactoryBL.getBL().getDish(id);
            textBoxDishName.Text = mydish.DishName;
            textBoxPrice.Text = mydish.Price.ToString();
            comboBoxSize.SelectedValue = mydish.Godel;
            comboBoxHechsher.SelectedValue = mydish.RamatHechsher;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window DishWindow = new DishWindow();
            DishWindow.Show();
            Close();
        }

    }
}
