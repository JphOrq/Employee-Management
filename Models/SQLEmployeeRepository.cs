using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly NewEmployeeDB context;

        public SQLEmployeeRepository(NewEmployeeDB context)
        {
            this.context = context;
        }

        public Employee Add(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return emp;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee Update(Employee empChanges)
        {
            var employee = context.Employees.Attach(empChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return empChanges;
        }
    }
}