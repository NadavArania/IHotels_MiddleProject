using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Models.Enums
{
    public enum UserType
    {
        Admin,
        Manager,
        Employee
    }

    public enum RoomType
    {
        Single,
        Twin,
        Double,
        Deluxe,
        Suites
    }

    public enum RoleDepartment
    {
        DiningRoom,
        Pool,
        Secutiry,
        Reception,
        Cleaning,
        Maintance,
        Bar,
        Entertainment,
        Managment
    }
}
