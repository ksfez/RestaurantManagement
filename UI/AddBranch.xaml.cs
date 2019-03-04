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
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : Window
    {
        Branch mybranch;
        public AddBranch()
        {
            InitializeComponent();
            mybranch = new Branch();
            this.DataContext = mybranch;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));//we put values of hechsher in the comboBox
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));//we put values of town in the comboBox
        }

        void Add(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            bl.addBranch(mybranch);//we add the branch

            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();//got to the main window where is the main menu
            Close();

        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();
            Close();
        }
    }
}
