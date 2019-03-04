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
using DAL;

namespace UI
{
    public partial class DeleteBranch : Window
    {

        public DeleteBranch()
        {
            InitializeComponent();
            ComboID.ItemsSource = BL.FactoryBL.getBL().getAllBranches().Select(b => b.BranchNum);
        }

        void DeleteClick(object sender, RoutedEventArgs e)
        {
            IBL bl = FactoryBL.getBL();
            bl.removeBranch((int)ComboID.SelectedItem);//remove branch
            Window Branch = new BranchWindow();
            Branch.Show();
            Close();
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window Branch = new BranchWindow();
            Branch.Show();
            Close();
        }
    }

}
