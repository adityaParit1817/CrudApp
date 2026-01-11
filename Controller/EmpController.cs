using CrudApp.Data;
using CrudApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("Get-All")]
        public async  Task<IActionResult> GetEmp()
        {
            var data = await _context.Employees.ToListAsync();
            return Ok(new 
                {
            Message ="Employee Fetch Successfully",
                data = data
            });
        }


        [HttpPost("Add-Emp")]
        public async Task<IActionResult> AddEmp(Employee Emp)
        {
           if(Emp == null)
            {
                return BadRequest("Plaes entyer valid crenditails");
            }

           await _context.Employees.AddAsync(Emp);
           await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Employee add Succesfully ",
                data = Emp

            });

        }

        [HttpPut("Update-Emp")]
        public async Task<IActionResult> UpdateEmp(Employee emp, int id)
        {
            var data = await _context.Employees.FindAsync(id);

            if(data == null)
            {
                return NotFound("Theri is a no data found in that id:");
            }
            data.Name = emp.Name;
            data.Description = emp.Description;
            data.Age = emp.Age;
            data.Department = emp.Department;

            await _context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpDelete("Emp-Delete")]
        public async Task<IActionResult> DeleteEmp(int id )
        {
            if(id <=0)
            {
                return NotFound("please enter id");
            }

            var data = await _context.Employees.FindAsync(id);

            if (data == null)
            {
                return NotFound("There is no data found in that id:");
            }

             _context.Employees.Remove(data);
            await _context.SaveChangesAsync();


            return Ok(new
            {
                message = $"Employee is deleted Successfully id is ={data.Id} "

            });

        }
    }
}
