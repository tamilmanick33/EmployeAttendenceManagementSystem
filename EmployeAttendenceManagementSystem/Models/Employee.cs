using System.ComponentModel.DataAnnotations;

namespace EmployeAttendenceManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="* Please Mention The Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Please Mention The EmailID")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Please Mention The Department Name")]
        public string Department { get; set; }
    }
}
