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

namespace UI
{
    /// <summary>
    /// Interaction logic for ShowBranches.xaml
    /// </summary>
    public partial class ShowBranches : Window
    {
        private List<Branch> mybranch;
        private Branch branch_choisi;
        private BL.IBL mybl = BL.FactoryBL.getBL();
        public ShowBranches()
        {
            InitializeComponent();
            mybranch = mybl.getAllBranches().ToList();
            this.DataContext = mybranch;
        }
        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();
            Close();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateBranch wind = new UpdateBranch(branch_choisi);
            wind.ShowDialog();
            Close();

        }

        private void branchDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            branch_choisi = (Branch)branchDataGrid.SelectedItem;
            buttonUpdate.IsEnabled = true;
        }
    }
}
