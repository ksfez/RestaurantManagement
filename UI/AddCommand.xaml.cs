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
using System.IO;
using BL;
using DAL;
using BE;
using System.Globalization;
using System.Xml.Linq;


namespace UI
{
    /// <summary>
    /// Interaction logic for AddOrderedDish.xaml
    /// </summary>
    public partial class AddCommand : Window
    {
        double maxPrice = 0;
        Town t;
        public static Order myOrder;
        
        public AddCommand()
        {
            InitializeComponent();
            myOrder = new Order();
            this.DataContext = myOrder;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(Hechsher));//we put values of hechsher in the comboBox
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));//we put values of town in the comboBox
            
            TextBoxPrice.Visibility = Visibility.Hidden;//we can't see this textBox
            TextBlockPrice.Visibility = Visibility.Hidden;//we can't see this textBlock
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            try
            {
                IBL bl = FactoryBL.getBL();
                myOrder.Date = (DateTime)DatePicker.SelectedDate;//we put in the myorder.date the date enter by the user
                int neworderid = bl.addOrder(myOrder);//add the order
                myOrder.OrderBranch = FactoryBL.getBL().getBranchID((string)comboBoxBranch.SelectedItem);
                if (CheckBoxPrice.IsChecked == true)//if the client want a max price
                    maxPrice = Convert.ToDouble(TextBoxPrice.Text);
                if (DatePicker.SelectedDate == null)
                    throw new Exception();
                if (maxPrice != 0)
                {
                    if (FactoryBL.getBL().MaxPrice(maxPrice).FirstOrDefault() == null)
                    {
                        MessageBox.Show("there is no dish available for this price!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Window ChoiceDish = new ChoiceDish(neworderid, maxPrice);//if the client want a maxPrice we go to choice dish by sending two parameters
                    ChoiceDish.Show();
                    Close();
                }
                else
                {
                    Window ChoiceDish = new ChoiceDish(neworderid);//if the client want a maxPrice we go to choice dish by sending one parameter
                    ChoiceDish.Show();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a date", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            //if we checked the checkbox the textbox and the textblock Price
            TextBoxPrice.Visibility = Visibility.Visible;
            TextBlockPrice.Visibility = Visibility.Visible;
        }

        private void comboBoxHechsher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxBranch.ItemsSource = BL.FactoryBL.getBL().CheckBranch(t, (Hechsher)(comboBoxHechsher.SelectedItem)).Select(b => b.BranchName);//we define the value of the combbox branch according to the hechsher wanted by the user
            if (FactoryBL.getBL().CheckBranch(t, (Hechsher)(comboBoxHechsher.SelectedItem)).FirstOrDefault() == null)
            {
                MessageBox.Show("there is no branch available!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (FactoryBL.getBL().CheckDishHechsher((Hechsher)myOrder.Hechsher).FirstOrDefault() == null)
            {
                MessageBox.Show("there is no dish available for this hechsher!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void ComboBoxTown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t = (Town)(ComboBoxTown.SelectedItem);//we put the town selected by the user in t
            comboBoxBranch.ItemsSource = BL.FactoryBL.getBL().CheckBranch(t, (Hechsher)(comboBoxHechsher.SelectedItem)).Select(b => b.BranchName);//we define the value of the combbox branch according to the hechsher wanted by the user
            if (FactoryBL.getBL().CheckBranch(t, (Hechsher)(comboBoxHechsher.SelectedItem)).FirstOrDefault() == null)
            {
                MessageBox.Show("there is no branch available", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            Close();
        }
   
    }
}
