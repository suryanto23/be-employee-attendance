namespace be_employee_attendance.PostModel
{
    public class PostEmployeeAttendance
    {
        public string AttendanceDate { get; set; }
        public string ClockIn { get; set; }
        public string ClockOut { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
