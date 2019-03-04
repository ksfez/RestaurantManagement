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
using BE;
using DS;
using DAL;
using BL;

namespace UI
{
    /// <summary>
    /// Interaction logic for BranchWindow.xaml
    /// </summary>
    public partial class BranchWindow : Window
    {
       

        public BranchWindow()
        {
            InitializeComponent();
        }

        private void AddBranchClick(object sender, RoutedEventArgs e)
        {
            Window AddBranch = new AddBranch();
            AddBranch.Show();
            this.Close();
        }
        private void DeleteBranchClick(object sender, RoutedEventArgs e)
        {

            try
            {
                if (FactoryBL.getBL().getAllBranches().ToList().FirstOrDefault() != null)
                {
                    Window DeleteBranch = new DeleteBranch();
                    DeleteBranch.Show();
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no branch!", "Branch", MessageBoxButton.OK, MessageBoxImage.Error);
                Window MainWindow = new MainWindow();
                MainWindow.Show();
            }
            Close();
        }
        private void UpdateBranchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FactoryBL.getBL().getAllBranches().ToList().FirstOrDefault() != null)
                {
                    Window UpdateBranch = new UpdateBranch();
                    UpdateBranch.Show();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no branch!", "Branch", MessageBoxButton.OK, MessageBoxImage.Error);
                Window MainWindow = new MainWindow();
                MainWindow.Show();
            }
            this.Close();
        }
        private void GetAllBranchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Branch> allbranches;
                allbranches=FactoryBL.getBL().getAllBranches().ToList();
                if (allbranches!= null)
                {
                    Window ShowBranches = new ShowBranches();
                    ShowBranches.Show();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("There is no branch!", "Branch", MessageBoxButton.OK, MessageBoxImage.Error);
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
