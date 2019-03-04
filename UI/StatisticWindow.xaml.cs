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

namespace UI
{
    /// <summary>
    /// Interaction logic for StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        public StatisticWindow()
        {
            InitializeComponent();
        }
        void DateClick(object sender, RoutedEventArgs e)
        {
            Window DateStatistic = new DateStatistic();
            DateStatistic.Show();
            this.Close();
        }
        void AdressClick(object sender, RoutedEventArgs e)
        {
            Window AdressStatistic = new AdressStatistic();
            AdressStatistic.Show();
            this.Close();
        }
        void PodiumAClick(object sender, RoutedEventArgs e)
        {
            Window PodiumAdress = new PodiumAdress();
            PodiumAdress.Show();
            this.Close();
        }
        void PodiumDClick(object sender, RoutedEventArgs e)
        {
            Window PodiumDate = new PodiumDate();
            PodiumDate.Show();
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
