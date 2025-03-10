using Module_4.DTO;
using Module_4.Models.Entities;

namespace Module_4.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, UpdateEmployeedto updateEmployeeDto);
        void DeleteEmployee(int id);
    }
}
