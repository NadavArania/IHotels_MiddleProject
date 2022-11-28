using IHotels.Viewer.Core;
using IHotels.Viewer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.ViewModel
{
    public class GuestsViewModel : ObserveableObject
    {
        //Connect with guests View and sending function to it.
        public GuestsViewModel()
        {
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
        }

        public IEnumerable<object> GetGuestsDetails()
        {
            var guestsDetails = from c in IConnectorDb.db.Customers
                                 select new { c.FirstName, c.LastName, c.Email, c.BirthDay ,c.AddedDate, c.PhoneNumber, c.Address,c.City, c.Region, c.Booking.Number, c.Booking.EnterDate, c.Booking.ExitDate };
            return guestsDetails.ToList();
        }
    }
}
