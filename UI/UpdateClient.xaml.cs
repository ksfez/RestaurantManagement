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
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class UpdateClient : Window
    {
        double maxPrice = 0;
        Town t;
        public Order myorder = new Order();
        int neworderid;
        public UpdateClient()
        {
            InitializeComponent();
            try
            {
                if (BL.FactoryBL.getBL().getAllOrders().FirstOrDefault() == null)
                {
                    throw new Exception();
                }
                ComboBoxName.ItemsSource = BL.FactoryBL.getBL().getAllOrders().Select(b => b.OrderName);
                TextBoxPrice.Visibility = Visibility.Hidden;//we can't see this textBox
                TextBlockPrice.Visibility = Visibility.Hidden;//we can't see this textBlock
                comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(Hechsher));//we put values of hechsher in the comboBox
                ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));//we put values of town in the comboBox
            }
            catch (Exception)
            {
                MessageBox.Show("There is no client!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Window Command = new CommandWindow();
                Command.Show();
                Close();
            }

        }

        private void ComboBoxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = (string)ComboBoxName.SelectedItem;
            myorder = BL.FactoryBL.getBL().getOrder(name);
            textBoxAdress.Text = myorder.OrderAdress;
            textBoxDeliveryAdress.Text = myorder.DeliveryAdress;
            comboBoxHechsher.SelectedValue = myorder.Hechsher;
            ComboBoxTown.SelectedValue = myorder.Town;
            textBoxCard.Text = myorder.Card.ToString();
            textBoxAdress.Text = myorder.OrderAdress;
            comboBoxBranch.SelectedValue = myorder.OrderBranch;
        }
        private void Add(object sender, RoutedEventArgs e)
        {

            try
            {
                IBL bl = FactoryBL.getBL();

                myorder.OrderBranch = FactoryBL.getBL().getBranchID((string)comboBoxBranch.SelectedItem);


                if (CheckBoxPrice.IsChecked == true)//if the client want a max price
                    maxPrice = Convert.ToDouble(TextBoxPrice.Text);

                if (DatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Enter a date", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    myorder.Date = (DateTime)DatePicker.SelectedDate;//we put in the myorder.date the date enter by the user
                    if (myorder.Date != FactoryBL.getBL().getOrder(myorder.Order_ID).Date)
                        neworderid=FactoryBL.getBL().addOrder(myorder);
                    else
                        neworderid = bl.changeOrder(myorder);//update the order
                }

                if (maxPrice != 0)
                {
                    if (neworderid != 0)
                    {
                        Window ChoiceDish = new ChoiceDish(neworderid, maxPrice);//if the client want a maxPrice we go to choice dish by sending two parameters
                        ChoiceDish.Show();
                        Close();
                    }
                    else throw new Exception();
                }
                else
                {
                    if (neworderid != 0)
                    {
                        Window ChoiceDish = new ChoiceDish(neworderid);//if the client want a maxPrice we go to choice dish by sending one parameter
                        ChoiceDish.Show();
                        Close();
                    }
                    else throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This client doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Window Client = new Client();
                Client.Show();
                Close();
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
                MessageBox.Show("there is no branch available", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (FactoryBL.getBL().CheckDishHechsher((Hechsher)myorder.Hechsher).FirstOrDefault() == null)
            {
                MessageBox.Show("there is no dish available", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
