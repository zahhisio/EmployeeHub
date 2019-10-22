using EmployeeHub.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHub.DAL
{
    public class EmployeeListDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EmployeeListDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
