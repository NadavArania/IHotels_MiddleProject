using IHotels.Viewer.Models.CustomerResources;
using IHotels.Viewer.Models.EmployeeResources;
using IHotels.Viewer.Models.HotelResources;
using IHotels.Viewer.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.Context
{
    public class IHotelsContext : DbContext
    {
        //Employee Resources
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Hotel Resources
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Room> Rooms { get; set; }

        //Customer Resources
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-LCMU98BH;Database=IHotelsDb;Trusted_Connection=True;");
        }
    }
}
