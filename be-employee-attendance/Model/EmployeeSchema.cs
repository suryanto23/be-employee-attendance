using System.ComponentModel.DataAnnotations.Schema;

namespace be_employee_attendance.Model
{
    public class EmployeeSchema
    {
    
        public Guid Id { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string DateOfBirth { get; set;}
        public string PlaceOfBirth { get; set;}
        public string JoinDate { get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
    }
}
