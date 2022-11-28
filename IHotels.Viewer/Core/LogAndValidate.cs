using IHotels.Viewer.Models.Enums;
using IHotels.Viewer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IHotels.Viewer.Core
{
    public class LogAndValidate
    {
        //Permission between users and funcitonal checking.

        public bool IsLoggedIn = false;
        public bool IsAuthorize = false;
        public static List<Employee> LoggedUser = new List<Employee>();
        Employee employee;

        public LogAndValidate()
        {
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
        }

        public bool UserCanLogin(string email)
        {
            if(CheckIfUserExists(email))
            {
                employee = IConnectorDb.db.Employees.Single(x => x.Email == email);
                if (employee.Email == email)
                {
                    IsLoggedIn = true;
                    LoggedUser.Add(employee);
                    return IsLoggedIn;
                }
                else
                {
                    return IsLoggedIn = false;
                }
            }
            return IsLoggedIn;
        }

        public bool UserLogedOut()
        {
            Employee employee = LoggedUser.First();
            if (employee != null)
            {
                LoggedUser.Remove(employee);
                return IsLoggedIn = false;
            }
            else
            {
                return IsLoggedIn = true;
            }
        }

        public bool Authorize()

        {
            switch (LoggedUser.First().UserType)
            {
                case UserType.Admin:
                    IsAuthorize = true;
                    break;

                case UserType.Manager:
                    IsAuthorize = false;
                    break;

                    default:
                    IsAuthorize = false;
                    break;
            }
            return IsAuthorize;
        }

        public bool EmailRegex(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfUserExists(string email)
        {
            return IConnectorDb.db.Employees.Where(x => x.Email == email).Any();
        }


        public bool CheckIfBookingExists(string email)
        {
            return IConnectorDb.db.Bookings.Where(x => x.Customer.Email == email).Any();
        }
    }
}
