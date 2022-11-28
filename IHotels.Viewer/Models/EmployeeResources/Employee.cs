using IHotels.Viewer.Models.EmployeeResources;
using IHotels.Viewer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.User
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public DateTime HireDate { get; set; }
        public int? SalesCount { get; set; }
        public DateTime? LastSale { get; set; }
        public int RestDaysCount { get; set; }
        public Role Role { get; set; }
    }
}
