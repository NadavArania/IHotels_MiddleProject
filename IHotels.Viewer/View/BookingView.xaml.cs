using IHotels.Viewer.Core;
using IHotels.Viewer.ViewModel;
using IHotels.Viewer.Windows;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace IHotels.Viewer.View
{
    public partial class BookingView : UserControl
    {
        //Connect with booking ViewModel and control the final view.

        BookingViewModel bvm = new BookingViewModel();
        AddBookingWindow abw = new AddBookingWindow();
        UpdateBookingWindow ubw = new UpdateBookingWindow();
        public static string id;
        public static string roomNum;
        LogAndValidate lav = new LogAndValidate();

        public BookingView()
        {
            InitializeComponent();
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
            this.DgBooking.ItemsSource = bvm.GetBookingDetails();
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
                abw.Show();
        }

        private void BtnRemoveBooking_Click(object sender, RoutedEventArgs e)
        {
            if(id != null && roomNum != null)
            {
                    bvm.DeleteBooking(id, roomNum);
            }
            else
            {
                MessageBox.Show("Please select a book!");
            }
        }

        private void BtnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            if (id != null && roomNum != null)
            {
                    ubw.Show();
            }
            else
            {
                MessageBox.Show("Please select a book!");
            }
            
        }

        private void DgBooking_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var cellInfo = DgBooking.SelectedCells[0];
            id = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            var cellRoom = DgBooking.SelectedCells[4];
            roomNum = (cellRoom.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
        }

        private void DgBooking_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            var currentCell = e.ClipboardRowContent[DgBooking.CurrentCell.Column.DisplayIndex];
            e.ClipboardRowContent.Clear();
            e.ClipboardRowContent.Add(currentCell);
        }
    }
}
