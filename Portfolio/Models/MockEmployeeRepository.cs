using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Kuldeep Singh Chouhan", Department = Department.Microsoft, Email = "kschouhan714@gmail.com", Designation = "Intern"},
                new Employee() {Id = 2, Name = "Sunny Narula", Department = Department.Microsoft, Email = "sunny.na@cisinlabs.com", Designation = "Assistant Team Lead"},
                new Employee() {Id = 3, Name = "Sagar Soni", Department = Department.Microsoft, Email = "sagar.so@cisinlabs.com", Designation = "Intern"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employee.Name;
                employee.Email = employee.Email;
                employee.Department = employee.Department;
            }
            return employee;
        }
    }
}
