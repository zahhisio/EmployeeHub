using EmployeeHub.Models.Models;
using EmployeeHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeHub.Web.API
{
    public class EmployeeApiController : ApiController
    {
        private readonly IEmployeeData db;

        public EmployeeApiController(IEmployeeData db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
