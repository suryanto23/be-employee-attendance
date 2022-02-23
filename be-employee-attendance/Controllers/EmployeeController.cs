using be_employee_attendance.Data;
using be_employee_attendance.Model;
using be_employee_attendance.PostModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_employee_attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IndexContext _context;
        public EmployeeController(IndexContext source)
        {
            _context = source;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            EmployeeSchema employee = _context.Employees.Where(item => item.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return StatusCode(404, "Employee ID not found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post(PostEmployee model)
        {
            EmployeeSchema employee = new EmployeeSchema();
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.PlaceOfBirth = model.PlaceOfBirth;
            employee.JoinDate = model.JoinDate;

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PutEmployee model)
        {
            EmployeeSchema employee = _context.Employees.Where(item => item.Id == model.Id).FirstOrDefault();
            if (employee == null)
            {
                return StatusCode(404, "Employee no found");
            };

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.PlaceOfBirth = model.PlaceOfBirth;
            employee.JoinDate = model.JoinDate;
            
            _context.Employees.Update(employee).Property(item => item.Code).IsModified = false;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteEmployee model)
        {
            EmployeeSchema employee = _context.Employees.Where(item => item.Id == model.Id).FirstOrDefault();
            if (employee == null)
            {
                return StatusCode(404, "Employee not found");
            };

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}
