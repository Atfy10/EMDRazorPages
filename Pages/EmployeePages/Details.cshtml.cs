using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementDashboard.Models;

namespace EmployeeManagementDashboard.Pages.EmployeePages;

public class DetailsModel : PageModel
{
    private readonly EmployeeManagementDashboardContext _context;
    public DetailsModel(EmployeeManagementDashboardContext context)
    {
        _context = context;
    }

    public Employee Employee { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
        if (employee is null)
        {
            Employee = new Employee
            {
                FirstName = "Employee not found",
                LastName = "Employee not found",
                Email = "Employee not found",
                Phone = "Employee not found",
                Department = "Employee not found",
                Position = Position.ProjectManager,
                Salary = 0,
                HireDate = DateTime.MinValue,
                IsActive = false
            };
            return Page();
            return NotFound();
        }
        else
        {
            Employee = employee;
        }

        return Page();
    }
}
