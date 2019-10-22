using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHub.Models.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name must be filled in.")]
        public string Name { get; set; }


        public DateTime BirthDate { get; set; }

        //[Required(ErrorMessage = "Employee age must be filled in.")]
        public int Age { get; set; }

        //[Required(ErrorMessage = "Please insert a skill.")]
        public Skill Skill { get; set; }
    }
}
