using RestApiAzure.Models;

namespace RestApiAzure.Services;

public interface IEmployeeService
{
    Task<Employee> Get(int id);

    Task<IEnumerable<Employee>> GetAll();

    Task<int> Add(Employee employee);
}
