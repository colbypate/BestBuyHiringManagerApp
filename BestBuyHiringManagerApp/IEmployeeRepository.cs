using BestBuyHiringManagerApp.Models;

namespace BestBuyHiringManagerApp
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);
        public void UpdateEmployee(Employee employee);
        public void InsertEmployee(Employee employeeToInsert);
        public Employee AddEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
    }
}
