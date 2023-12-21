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
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return userNameTextBox.Text; }
        }

        public string Password
        {
            get { return passwordTextBox.Text; }
        }

        // New read-only properties for external access
        public string ReadOnlyUserName
        {
            get { return UserName; }
        }

        public string ReadOnlyPassword
        {
            get { return Password; }
        }
    }
}
