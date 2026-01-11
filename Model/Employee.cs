using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public int Age { get; set; }

        public string? Department { get; set; }

        public string? Description { get; set; }
    }

  
}
