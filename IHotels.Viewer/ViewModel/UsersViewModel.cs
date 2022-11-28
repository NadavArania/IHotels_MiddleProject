using IHotels.Viewer.Core;
using IHotels.Viewer.Models.Enums;
using IHotels.Viewer.Models.User;
using IHotels.Viewer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IHotels.Viewer.ViewModel
{
    public class UsersViewModel : ObserveableObject
    {
        //Connect with users(emoloyess) View and sending function to it.

        private object _currentState;
        public object CurrentState { get { return _currentState; } set { _currentState = value; OnPropertyChanged(); } }
        public RelayCommand State { get; set; }

        public UsersViewModel()
        {
            IConnectorDb.db = DbConnector.GetInstance.GetDb();
        }

        public void CreateEmployee(string fname, string lname, string paswrd, string mail, DateTime bd, string address, string city, string region, int ut, int roleDep)
        {

            if (IConnectorDb.db.Employees.Where(x => x.Email == mail).Any())
            {
                MessageBox.Show("This email already used!");
            }
            else
            {
                Employee employee;

                    employee = new Employee()
                    {
                        FirstName = fname,
                        LastName = lname,
                        Password = paswrd,
                        Email = mail,
                        BirthDay = bd,
                        Address = address,
                        City = city,
                        Region = region,
                        HireDate = DateTime.Now,
                        LastSale = null,
                        PhoneNumber = GeneratePhone(),
                        RestDaysCount = 0,
                        SalesCount = 0,
                        UserType = (UserType)ut
                    };
                    employee.Role = IConnectorDb.db.Roles.Single(x => x.RoleDepartment == (RoleDepartment)roleDep);
                    IConnectorDb.db.Employees.Add(employee);
                    IConnectorDb.db.SaveChanges();
                    CurrentState = employee;
                    State = new RelayCommand(o => CurrentState = employee);
            }
        }

        public void EditEmployee(string id, string mail, string paswrd, string address, string city, string region, int ut, int roleDep, int restDayCount)
        {
            Employee editEmployee = IConnectorDb.db.Employees.Where(x => x.Id == int.Parse(id)).First();
            editEmployee.Email = mail;
            editEmployee.Password = paswrd;
            editEmployee.Address = address;
            editEmployee.City = city;
            editEmployee.Region = region;
            editEmployee.UserType = (UserType)ut;
            editEmployee.Role.RoleDepartment = (RoleDepartment)roleDep;
            editEmployee.RestDaysCount = restDayCount;

            IConnectorDb.db.SaveChanges();
        }


        public void DeleteEmployee(string id)
        {
            Employee employeeToRemove = IConnectorDb.db.Employees.Single(x => x.Id == int.Parse(id));
            IConnectorDb.db.Employees.Remove(employeeToRemove);
            IConnectorDb.db.SaveChanges();
        }

        public IEnumerable<object> GetEmployeeDetails()
        {
            var employeeDetails = from e in IConnectorDb.db.Employees
                              select new {e.Id, e.FirstName , e.LastName , e.Email, e.UserType, e.Role.Title, e.HireDate, e.BirthDay, e.PhoneNumber, e.Address, e.City, e.Region, e.RestDaysCount,
                              e.LastSale, e.SalesCount};
            return employeeDetails.ToList();
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
    }
}
