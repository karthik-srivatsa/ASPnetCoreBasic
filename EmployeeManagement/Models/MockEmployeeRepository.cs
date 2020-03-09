using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee{Id=1,Name="Karthik",Department=Dept.Engineering,Email="Karthik@gmail.com"},
                new Employee{Id=2,Name="Anusha",Department=Dept.QA,Email="Anusha@gmail.com"},
                new Employee{Id=3,Name="Chethan",Department=Dept.Engineering,Email="Chethan@gmail.com"},
                new Employee{Id=4,Name="Chidambar",Department=Dept.Support,Email="Chidambar@isha.com"},
                new Employee{Id=5,Name="Lekha",Department=Dept.Engineering,Email="lekhu@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
