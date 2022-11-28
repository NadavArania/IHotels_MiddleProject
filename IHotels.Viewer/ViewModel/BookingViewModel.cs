using IHotels.Viewer.Core;
using IHotels.Viewer.Models.CustomerResources;
using IHotels.Viewer.Models.HotelResources;
using IHotels.Viewer.Models.User;
using IHotels.Viewer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.ViewModel
{
    public class BookingViewModel : ObserveableObject
    {
        //Connect with booking View and sending function to it.
        public BookingViewModel()
        {
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
        }

        //Adding booking but also creating a new guest.
        public void CreateBooking(int roomNum, int empId, int numOfGuests, string custFName, string custLName, string custEmail, string custAddress, DateTime birthdate, string city, 
            string country , DateTime enterDate ,DateTime exitDate )
        {
            Room room = IConnectorDb.db.Rooms.Single(x=> x.Number == roomNum);
            Employee emp = IConnectorDb.db.Employees.Single(x => x.Id == empId);

            emp.LastSale = DateTime.Now;
            emp.SalesCount++;

            Booking booking;

            if (room.Availability)
            {
                booking = new Booking()
                {
                    Number = GenerateOrderNumber(),
                    EnterDate = enterDate,
                    ExitDate = exitDate,
                    CheckIn = new TimeSpan(14, 00, 0),
                    CheckOut = new TimeSpan(12, 00, 0),
                    NumberOfGuests = numOfGuests > room.Capacity ? room.Capacity : numOfGuests,
                    Emplyee = emp,
                    Room = room,
                    Customer = new Customer()
                    {
                        FirstName = custFName,
                        LastName = custLName,
                        Email = custEmail,
                        Address = custAddress,
                        AddedDate = DateTime.Now,
                        PhoneNumber = GeneratePhone(),
                        BirthDay = birthdate,
                        City = city,
                        Region = country
                    }
                };

                TimeSpan df = booking.EnterDate - booking.ExitDate;
                int td = (int)Math.Abs(Math.Round(df.TotalDays));
                booking.TotalPrice = room.Price * Convert.ToDouble(td);
                booking.Room.Availability = false;
                
                IConnectorDb.db.Bookings.Add(booking);
                IConnectorDb.db.SaveChanges();
            }
        }

        //Edit booking but also editing a guest.

        public void EditBooking(string id,string custmail, string address, string city, string region, DateTime exitDate)
        {
            Booking editBooking = IConnectorDb.db.Bookings.Where(x => x.Id == int.Parse(id)).First();
            Customer editCustomer = editBooking.Customer;
            editCustomer.Email = custmail;
            editCustomer.Address = address;
            editCustomer.City = city;
            editCustomer.Region = region;
            editBooking.ExitDate = exitDate;

            IConnectorDb.db.SaveChanges();
        }

        //Delete booking but also deleting a guest.

        public void DeleteBooking(string id, string roomNum)
        {
            var bookingToRemove = IConnectorDb.db.Bookings.Single(x => x.Id == int.Parse(id));
            var customerToRemove = IConnectorDb.db.Customers.Single(x => x.Id == bookingToRemove.Id);
            var roomNumberToAvilable = IConnectorDb.db.Rooms.Single(x => x.Number == int.Parse(roomNum));
            roomNumberToAvilable.Availability = true;
            IConnectorDb.db.Customers.Remove(customerToRemove);
            IConnectorDb.db.Bookings.Remove(bookingToRemove);
            IConnectorDb.db.SaveChanges();
        }

        public int GenerateOrderNumber()
        {
            Random rnd = new Random();
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                strb.Append(rnd.Next(0, 9).ToString());
            }
            var str = strb.ToString();
            return int.Parse(str);
        }

        public string GeneratePhone()
        {
            Random random = new Random();
            StringBuilder stb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                stb.Append(random.Next(0, 9));
            }
            return stb.ToString();
        }


        public IEnumerable<object> GetBookingDetails()
        {
            var bookingDetails = from b in IConnectorDb.db.Bookings
                                 select new {b.Id ,GuestName = b.Customer.FirstName + " " + b.Customer.LastName,b.NumberOfGuests, BookNumber = b.Number, RoomNumber = b.Room.Number, b.TotalPrice, b.EnterDate, b.ExitDate 
                                 ,EmployeeName = b.Emplyee.FirstName + " " + b.Emplyee.LastName , b.Customer.PhoneNumber};
            return bookingDetails.ToList();
        }
    }
}
