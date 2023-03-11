using Core.Models;

namespace Core.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
    }

    internal class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var list = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Employee
                {
                    Id = i,
                    FirstName = "First " + i,
                    LastName = "Last " + i,
                    Email = $"first_last_{i}@example.com",
                    IsRemote = i % 2 == 0,
                    Phone = "01234568" + i,
                    Gender = i % 2 == 0 ? "Male" : "Female",
                });
            }

            return await Task.FromResult(list);
        }
    }
}
