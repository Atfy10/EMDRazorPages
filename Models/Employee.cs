using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementDashboard.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(20, MinimumLength = 7,
            ErrorMessage = "Phone number must be between 7 and 20 characters.")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(200, ErrorMessage = "Department cannot exceed 200 characters.")]
        public string Department { get; set; } = string.Empty;

        [Required]
        public Position Position { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "1", "9999999999",
            ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; } = true;

        public string FullName => $"{FirstName} {LastName}";
    }
}
