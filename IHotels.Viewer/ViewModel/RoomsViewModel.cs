using IHotels.Viewer.Core;
using IHotels.Viewer.Models.HotelResources;
using IHotels.Viewer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.ViewModel
{
    public class RoomsViewModel : ObserveableObject
    {
        //Connect with rooms View and sending function to it.
        public IEnumerable<object> GetBookingDetails()
        {
            var roomDetails = from r in IConnectorDb.db.Rooms
                              select new {r.Number, r.RoomType, r.Capacity, r.Description, r.Price, r.HaveSafe, r.HavePorch, r.Availability};
            return roomDetails.ToList();
        }
    }
}
