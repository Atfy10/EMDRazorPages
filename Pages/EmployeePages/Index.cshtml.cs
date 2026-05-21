using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementDashboard.Models;

namespace EmployeeManagementDashboard.Pages.EmployeePages;

public class IndexModel : PageModel
{
    private readonly EmployeeManagementDashboardContext _context;

    public IndexModel(EmployeeManagementDashboardContext context)
    {
        _context = context;
    }

    public IList<Employee> Employee { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Employee = await _context.Employees.ToListAsync();
    }
}
