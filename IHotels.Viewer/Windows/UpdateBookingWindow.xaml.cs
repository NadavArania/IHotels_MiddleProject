using IHotels.Viewer.Core;
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

namespace IHotels.Viewer.Windows
{
    public partial class UpdateBookingWindow : Window
    {
        ////Window control updating functional to booking with events.

        BookingViewModel bvm = new BookingViewModel();
        BookingView bv;
        LogAndValidate lav = new LogAndValidate();

        public UpdateBookingWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void BtnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            //Checking field for updating booking.
            if (string.IsNullOrEmpty(TboxEmail.Text) || lav.CheckIfBookingExists(TboxEmail.Text) && lav.EmailRegex(TboxEmail.Text))
            {
                MessageBox.Show("Empty fields or unvalied email or taken email!");
            }
            else
            {
                bvm.EditBooking(BookingView.id,TboxEmail.Text, TboxAddress.Text, TboxCity.Text,TboxCountry.Text, DpExitDate.SelectedDate.Value);
                Hide();
            }
        }
    }
}
