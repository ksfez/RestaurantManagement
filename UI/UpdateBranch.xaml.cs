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
    /// <summary>
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : Window
    {
        List<Branch> b;
        Branch mybranch;
        public UpdateBranch()
        {
            mybranch = new Branch();
            InitializeComponent();
            b = BL.FactoryBL.getBL().getAllBranches().ToList();
            this.DataContext = b;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));
            comboBoxBranch.ItemsSource = b.Select(d => d.BranchNum);
        }

        public UpdateBranch(Branch branch_choisi)
        {
            
            InitializeComponent();
            b = BL.FactoryBL.getBL().getAllBranches().ToList();
            this.DataContext = b;
            comboBoxHechsher.ItemsSource = Enum.GetValues(typeof(BE.Hechsher));
            ComboBoxTown.ItemsSource = Enum.GetValues(typeof(BE.Town));
            comboBoxBranch.ItemsSource = b.Select(d => d.BranchNum);

            mybranch = branch_choisi;
            comboBoxBranch.SelectedValue = mybranch.BranchNum;
            textBoxName.Text = mybranch.BranchName;
            textBoxAdress.Text = mybranch.BranchAdress;
            textBoxSenders.Text = mybranch.BranchSenders.ToString();
            textBoxPhone.Text = mybranch.Phone.ToString();
            comboBoxHechsher.SelectedValue = mybranch.BranchHechsher;
            textBoxDirector.Text = mybranch.Director;
            textBoxWorkers.Text = mybranch.Workers.ToString();
            ComboBoxTown.SelectedValue = mybranch.BranchTown;
        }
        void Update(object sender, RoutedEventArgs e)
        {

            try
            {
                if (textBoxName.Text != "")
                {
                    mybranch.BranchName = textBoxName.Text;
                    mybranch.BranchAdress = textBoxAdress.Text;
                    mybranch.BranchSenders = Convert.ToInt32(textBoxSenders.Text);
                    mybranch.Phone = Convert.ToInt32(textBoxPhone.Text);
                    mybranch.BranchHechsher = (BE.Hechsher)comboBoxHechsher.SelectedValue;
                    mybranch.Director = textBoxDirector.Text;
                    mybranch.Workers = Convert.ToInt32(textBoxWorkers.Text);
                    mybranch.BranchTown = (BE.Town)ComboBoxTown.SelectedValue;

                    IBL bl = FactoryBL.getBL();
                    bl.changeBranch(mybranch);
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a name to continue", "Branch", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();
            Close();
        }
        private void comboBoxBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = (int)comboBoxBranch.SelectedItem;
            mybranch = BL.FactoryBL.getBL().getBranch(id);
            textBoxName.Text = mybranch.BranchName;
            textBoxAdress.Text = mybranch.BranchAdress;
            textBoxSenders.Text = mybranch.BranchSenders.ToString();
            textBoxPhone.Text = mybranch.Phone.ToString();
            comboBoxHechsher.SelectedValue = mybranch.BranchHechsher;
            textBoxDirector.Text = mybranch.Director;
            textBoxWorkers.Text = mybranch.Workers.ToString();
            ComboBoxTown.SelectedValue = mybranch.BranchTown;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();
            Close();
        }
    }
}

