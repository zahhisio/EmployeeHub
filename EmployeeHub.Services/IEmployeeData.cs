using EmployeeHub.Models.Models;
using System.Collections.Generic;

namespace EmployeeHub.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Add(Employee employee);
        void Update(Employee employee, int id);
        void Delete(int id);
    }
}
