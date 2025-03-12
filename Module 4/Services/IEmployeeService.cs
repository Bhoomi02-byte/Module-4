using Module_4.DTO;
using Module_4.Models.Entities;

namespace Module_4.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(int id, UpdateEmployeedto updateEmployeeDto);
        Task DeleteEmployee(int id);
    }
}
