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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }
        private void NewClick(object sender, RoutedEventArgs e)
        {
            Window AddCommand = new AddCommand();
            AddCommand.Show();
            this.Close();
        }
        private void OldClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Window UpdateClient = new UpdateClient();
                UpdateClient.Show();
                this.Close();
            }
            catch (Exception)
            {
                this.Close();
            }
        }
    }
}
