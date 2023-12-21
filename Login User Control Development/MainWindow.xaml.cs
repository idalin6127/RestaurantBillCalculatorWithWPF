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

namespace Lab3_Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // Handle button click to retrieve login information
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetLoginInfo_Click(object sender, RoutedEventArgs e)
        {
            string userName = loginControl.UserName;
            string password = loginControl.Password;
            string readOnlyUserName = loginControl.ReadOnlyUserName;
            string readOnlyPassword = loginControl.ReadOnlyPassword;

            MessageBox.Show($"Username: {userName} is registered! Log in successfully!");
        }
    }
}
