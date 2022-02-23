using be_employee_attendance.Data;
using be_employee_attendance.Model;
using be_employee_attendance.PostModel;
using be_employee_attendance.PutModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_employee_attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private IndexContext _context;
        public EmployeeAttendanceController(IndexContext source)
        {
            _context = source;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.EmployeeAttendances
                .Include(item => item.Employee)
                .ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            EmployeeAttendanceSchema attendance = _context.EmployeeAttendances
                .Where(item => item.Id == id)
                .Include(item => item.Employee)
                .FirstOrDefault();
            if (attendance == null)
            {
                return StatusCode(404, "Attendance ID not found");
            }
            return Ok(attendance);
        }

        [HttpPost]
        public IActionResult Post(PostEmployeeAttendance model)
        {
            EmployeeAttendanceSchema attendance = new EmployeeAttendanceSchema();
            attendance.AttendanceDate = model.AttendanceDate;
            attendance.ClockIn = model.ClockIn;
            attendance.ClockOut = model.ClockOut;
            attendance.EmployeeId = model.EmployeeId;

            _context.EmployeeAttendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PutEmployeeAttendance model)
        {
            EmployeeAttendanceSchema attendance = _context.EmployeeAttendances.Where(item => item.Id == model.Id).FirstOrDefault();
            if (attendance == null)
            {
                return StatusCode(404, "Attendance not found");
            };

            attendance.ClockOut = model.ClockOut;

            _context.EmployeeAttendances.Update(attendance);
            _context.SaveChanges();
            return Ok();
        }

    }
}
