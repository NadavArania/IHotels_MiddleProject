
using IHotels.Viewer.Core;
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

namespace IHotels.Viewer
{
    public partial class LoginWindow : Window
    {
        //Window login user with events.

        LogAndValidate lav = new LogAndValidate();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Checking field for login employee.
            if (lav.UserCanLogin(tboxEmail.Text) && lav.EmailRegex(tboxEmail.Text) || !string.IsNullOrEmpty(tboxEmail.Text) && !string.IsNullOrEmpty(pboxPassword.Password))
            {
                Close();
            }
            else
            {
                MessageBox.Show("One of the fields wrong!");
            }
        }
    }
}
