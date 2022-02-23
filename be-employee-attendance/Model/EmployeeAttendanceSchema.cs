namespace be_employee_attendance.Model
{
    public class EmployeeAttendanceSchema
    {
        public Guid Id { get; set; }
        public string AttendanceDate { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }

        public Guid EmployeeId { get; set; }
        public EmployeeSchema Employee { get; set; }
    }
}
