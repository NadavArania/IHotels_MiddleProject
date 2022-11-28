using IHotels.Viewer.Core;
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

namespace IHotels.Viewer.Windows
{
    public partial class AddBookingWindow : Window
    {
        //Window control adding booking to the system with events.

        BookingViewModel bvm = new BookingViewModel();
        LogAndValidate lav = new LogAndValidate();

        public AddBookingWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            //Checking field for adding booking.
            if (string.IsNullOrEmpty(TboxEmail.Text) || lav.CheckIfBookingExists(TboxEmail.Text) && lav.EmailRegex(TboxEmail.Text))
            {
                MessageBox.Show("Empty fields or unvalied email or taken email!");
            }
            else
            {
                if(IConnectorDb.db.Rooms.Where(x=> x.Availability == true).Any())
                {
                    bvm.CreateBooking(int.Parse(TboxRoomNum.Text), int.Parse(TboxEmpId.Text), int.Parse(TboxNoG.Text), TboxFirstName.Text, TboxLastName.Text, TboxEmail.Text, TboxAddress.Text,
                    DpBirthDate.SelectedDate.Value, TboxCity.Text, TboxCountry.Text, DpEntDate.SelectedDate.Value, DpExtDate.SelectedDate.Value);
                    Close();
                }
                else
                {
                    MessageBox.Show("Room already taken!");
                }
            }
        }
    }
}
