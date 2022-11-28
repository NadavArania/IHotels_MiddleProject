using IHotels.Viewer.Models.Enums;
using IHotels.Viewer.Models.HotelResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.EmployeeResources
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public RoleDepartment RoleDepartment { get; set; }
        public double Salary { get; set; }
        public TimeSpan? StartWork { get; set; }
        public TimeSpan? EndWork { get; set; }
        public Facility Facility { get; set; }
    }
}
