using Microsoft.EntityFrameworkCore;
using RestApiAzure.Models;

namespace RestApiAzure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeDBContext dBContext;

    public EmployeeService(EmployeeDBContext dBContext)
    {
        this.dBContext = dBContext;
    }

    public async Task<int> Add(Employee employee)
    {
        dBContext.Add(employee);
        await dBContext.SaveChangesAsync();

        return employee.Id;
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await dBContext.Employees.ToListAsync();
    }

    public async Task<Employee> Get(int id)
    {
        return await dBContext.Employees.Where(x=>x.Id == id).FirstOrDefaultAsync();
    }
}
