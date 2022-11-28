using IHotels.Viewer.Models.HotelResources;
using IHotels.Viewer.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.CustomerResources
{
    public class Booking
    {
        [ForeignKey("Customer")]
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public int NumberOfGuests { get; set; }
        public double TotalPrice { get; set; }
        public Employee Emplyee { get; set; }
        public Room Room { get; set; }
        public Customer Customer { get; set; }
    }
}
