using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public enum Department { HR, SALES, RnD}

    [Index(nameof(Email), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Field is Empty!!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field is Empty!!!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field is Empty!!!")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required(ErrorMessage = "Field is Empty!!!")]
        [EnumDataType(typeof(Department))]
        public Department Dept { get; set; }
        public DateOnly JoinDate { get; set; }
        public double Salary { get; set; }
    }
}
