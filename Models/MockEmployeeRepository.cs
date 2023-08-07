using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                //new Employee {
                //    Id = 1,
                //    FirstName = "Joseph",
                //    MiddleName = "Calimlim",
                //    LastName = "Orquita",
                //    Address = "B7 L8 Espina St., Caloocan City",
                //    Email = "joseph_orquita@yahoo.com",
                //    Department = Dept.IT,
                //    Salary = 100000},
                //new Employee {
                //    Id = 2,
                //    FirstName = "Karizza",
                //    MiddleName = "Contado",
                //    LastName = "Escanillas",
                //    Address = "Ph.9c Pkg.2, Caloocan City",
                //    Email = "kescanillas@gmail.com",
                //    Department = Dept.HR,
                //    Salary = 200000}
            };
        }

        public Employee Add(Employee emp)
        {
            emp.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(emp);
            return emp;
        }

        public Employee Delete(int id)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _employeeList.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee empChanges)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == empChanges.Id);
            if (emp != null)
            {
                emp.Id = empChanges.Id;
                emp.FirstName = empChanges.FirstName;
                emp.MiddleName = empChanges.MiddleName;
                emp.LastName = empChanges.LastName;
                emp.Address = empChanges.Address;
                emp.BirthDate = empChanges.BirthDate;
                emp.Email = empChanges.Email;
                emp.Department = empChanges.Department;
                emp.Salary = empChanges.Salary;
            }
            return emp;
        }
    }
}