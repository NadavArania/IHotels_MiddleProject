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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHotels.Viewer.View
{
    public partial class GuestsView : UserControl
    {
        //Connect with guests ViewModel and control the final view.

        GuestsViewModel gvm = new GuestsViewModel();

        public GuestsView()
        {
            InitializeComponent();
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
            this.dgGuests.ItemsSource = gvm.GetGuestsDetails();
        }
    }
}
