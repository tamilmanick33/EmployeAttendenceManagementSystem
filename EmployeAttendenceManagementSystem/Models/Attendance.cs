using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeAttendenceManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required(ErrorMessage ="Please mention Correct Id")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
       
        [Required(ErrorMessage = "Please Mention the Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Mention the CheckIn Time")]
        public TimeSpan CheckInTime { get; set; }
        [Required(ErrorMessage = "Please Mention the CheckOut Time")]
        public TimeSpan CheckOutTime { get; set; }
    }
}
