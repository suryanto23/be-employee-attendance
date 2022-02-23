namespace be_employee_attendance.PostModel
{
    public class PutEmployee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string JoinDate { get; set; }
    }
}
