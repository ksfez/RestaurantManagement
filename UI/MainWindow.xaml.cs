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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BranchClick(object sender, RoutedEventArgs e)
        {
            Window BranchWindow = new BranchWindow();
            BranchWindow.Show();
            this.Close();
        }
        private void CommandClick(object sender, RoutedEventArgs e)
        {
            Window CommandWindow = new CommandWindow();
            CommandWindow.Show();
            this.Close();
        }
        private void DishClick(object sender, RoutedEventArgs e)
        {
            Window DishWindow = new DishWindow();
            DishWindow.Show();
            this.Close();
        }
        private void StatisticClick(object sender, RoutedEventArgs e)
        {
            Window StatisticWindow = new StatisticWindow();
            StatisticWindow.Show();
            this.Close();
        }
    }
}
