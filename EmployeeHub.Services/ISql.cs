using EmployeeHub.DAL;
using EmployeeHub.Models.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmployeeHub.Services
{
    public class ISql : IEmployeeData
    {
        private readonly EmployeeListDbContext db;

        public ISql(EmployeeListDbContext db)
        {
            this.db = db;
        }
        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(e => e.Id == id); ;
        }

        public IEnumerable<Employee> GetAll()
        {
            return from e in db.Employees orderby e.Name select e;
        }

        public void Update(Employee employee, int id)
        {
            var existing = db.Employees.Find(id);

            existing.Name = employee.Name;
            existing.JoinDate = employee.JoinDate;
            existing.Age = employee.Age;
            existing.Skill = employee.Skill;

            var entry = db.Entry(existing);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
