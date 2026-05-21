using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementDashboard.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Phone Number")]
        [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [MinLength(7, ErrorMessage = "Phone number must be at least 7 characters.")]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = "Department cannot exceed 200 characters.")]
        public string Department { get; set; } = string.Empty;
        public Position Position { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
