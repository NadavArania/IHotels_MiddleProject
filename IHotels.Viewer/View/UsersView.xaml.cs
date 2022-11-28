
using IHotels.Viewer.Core;
using IHotels.Viewer.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace IHotels.Viewer.View
{
    public partial class UsersView : UserControl
    {
        //Connect with users(emoloyess) ViewModel and control the final view.

        AddEmployeeWindow aew = new AddEmployeeWindow();
        UpdateEmployeeWindow uew = new UpdateEmployeeWindow();
        UsersViewModel uvm = new UsersViewModel();
        public static string id;
        LogAndValidate lav = new LogAndValidate();
        public static int copy;

        public UsersView()
        {
            InitializeComponent();
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
            this.DgEmployees.ItemsSource = uvm.GetEmployeeDetails();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if(BtnAddUser.IsEnabled = lav.Authorize())
            {
                aew.Show();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {
                if(BtnEdit.IsEnabled = lav.Authorize())
                {
                    uew.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select user!");
            }
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(id != null)
            {
                if(BtnDeleteUser.IsEnabled = lav.Authorize())
                {
                    uvm.DeleteEmployee(id);
                }
            }
            else
            {
                MessageBox.Show("Please select user!");
            }
        }

        private void DgEmployees_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var cellInfo = DgEmployees.SelectedCells[0];
            id = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
        }

        private void DgEmployees_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            var currentCell = e.ClipboardRowContent[DgEmployees.CurrentCell.Column.DisplayIndex];
            e.ClipboardRowContent.Clear();
            e.ClipboardRowContent.Add(currentCell);
        }
    }
}
