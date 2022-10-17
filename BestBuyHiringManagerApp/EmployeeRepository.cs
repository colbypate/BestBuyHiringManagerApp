using BestBuyHiringManagerApp.Models;
using Dapper;
using System.Data;

namespace BestBuyHiringManagerApp
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _conn;

        public EmployeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("select * from employees;");
        }

        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("select * from employees where employeeid =@id",
                new { id = id });
        }

        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO employeess (FirstName, MiddleInitial, LastName, EmailAddress, PhoneNumber, Title, DateOfBirth) VALUES (@FirstName, @MiddleInitial, @LastName, @EmailAddress, @PhoneNumber, @Title, @DateOfBirth);",
                new { FirstName = employeeToInsert.FirstName, MiddleInitial = employeeToInsert.MiddleInitial, LastName = employeeToInsert.LastName, EmailAddress = employeeToInsert.EmailAddress, PhoneNumber = employeeToInsert.PhoneNumber, Title = employeeToInsert.Title, DateOfBirth = employeeToInsert.DateOfBirth });

        }
        public Employee AddEmployee()
        {
            var employee = new Employee();
            return employee;
        }


        public void UpdateEmployee(Employee employee)
        {
            _conn.Execute("update employees set FirstName = @FirstName, MiddleInitial = @MiddleInitial, LastName = @LastName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber,Title = @Title, DateOfBirth = @DateOfBirth where EmployeeID = @id",
                new { FirstName = employee.FirstName, MiddleInitial = employee.MiddleInitial, LastName = employee.LastName, EmailAddress = employee.EmailAddress, PhoneNumber = employee.PhoneNumber, Title = employee.Title, DateOfBirth = employee.DateOfBirth, id = employee.EmployeeID});
        }
    }
}
