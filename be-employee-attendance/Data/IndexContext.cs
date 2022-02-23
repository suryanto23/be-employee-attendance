using be_employee_attendance.Model;
using Microsoft.EntityFrameworkCore;

namespace be_employee_attendance.Data
{
    public class IndexContext : DbContext
    {

        public DbSet<EmployeeSchema> Employees { get; set; }
        public DbSet<EmployeeAttendanceSchema> EmployeeAttendances { get; set; }

        private readonly IConfiguration _configuration;

        public IndexContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {     
            builder.UseSqlServer(_configuration.GetConnectionString("defaultDbConfig"));
        }

    }

}
