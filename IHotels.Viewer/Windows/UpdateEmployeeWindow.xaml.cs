using IHotels.Viewer.Core;
using IHotels.Viewer.Models.Enums;
using IHotels.Viewer.View;
using IHotels.Viewer.ViewModel;
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
    public partial class UpdateEmployeeWindow : Window
    {
        //Window control updating functional to employee with events.

        UsersViewModel uvm = new UsersViewModel();
        LogAndValidate lav = new LogAndValidate();

        public UpdateEmployeeWindow()
        {
            InitializeComponent();
            this.CboxRoleDep.ItemsSource = Enum.GetValues(typeof(RoleDepartment));
            this.CboxUserType.ItemsSource = Enum.GetValues(typeof(UserType));
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            //Checking field for updating employee.
            if (string.IsNullOrEmpty(TboxEmail.Text) || string.IsNullOrEmpty(PboxPassword.ToString()) || lav.CheckIfUserExists(TboxEmail.Text) && lav.EmailRegex(TboxEmail.Text))
            {
                MessageBox.Show("Empty fields or unvalied email or taken email!");
            }
            else
            {
                uvm.EditEmployee(UsersView.id,TboxEmail.Text, PboxPassword.Password.ToString(), TboxAddress.Text, TboxCity.Text, TboxCountry.Text, CboxUserType.SelectedIndex, CboxRoleDep.SelectedIndex, int.Parse(TboxDaysLeft.Text));
                Hide();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
