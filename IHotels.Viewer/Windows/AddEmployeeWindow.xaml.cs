
using IHotels.Viewer.Core;
using IHotels.Viewer.Models.Enums;
using IHotels.Viewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddEmployeeWindow : Window
    {
        //Window control adding employee to the system with events.

        UsersViewModel uvm = new UsersViewModel();
        LogAndValidate lav = new LogAndValidate();

        public AddEmployeeWindow()
        {
            InitializeComponent();
            CboxRt.ItemsSource = Enum.GetValues(typeof(UserType));
            CrDepartment.ItemsSource = Enum.GetValues(typeof(RoleDepartment));
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //Checking field for adding employee.
            if (string.IsNullOrEmpty(TboxEmail.Text) || string.IsNullOrEmpty(PboxPassword.ToString()) || lav.CheckIfUserExists(TboxEmail.Text) && lav.EmailRegex(TboxEmail.Text))
            {
                MessageBox.Show("Empty fields or unvalied email or taken email!");
            }
            else
            {
                uvm.CreateEmployee(TboxFirstName.Text, TboxLastName.Text, PboxPassword.ToString(), TboxEmail.Text, DatePick.SelectedDate.Value,
                TboxAddress.Text, TboxCity.Text, TboxCountry.Text, CboxRt.SelectedIndex, CrDepartment.SelectedIndex);
                Close();
            }
        }
    }
}
