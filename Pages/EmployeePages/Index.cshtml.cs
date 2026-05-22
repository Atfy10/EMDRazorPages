using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementDashboard.Models;

namespace EmployeeManagementDashboard.Pages.EmployeePages;

public class IndexModel : PageModel
{
    private readonly EmployeeManagementDashboardContext _context;
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }
    public IReadOnlyList<Employee> Employees { get; set; } = default!;

    public IndexModel(EmployeeManagementDashboardContext context)
    {
        _context = context;
    }


    public async Task OnGetAsync()
    {
        var query = _context.Employees.AsQueryable();

        if (SearchString != null)
        {
            query = query.Where(e =>
                e.FirstName.Contains(SearchString) ||
                e.LastName.Contains(SearchString) ||
                e.Email.Contains(SearchString) ||
                e.Phone.Contains(SearchString) ||
                e.Department.Contains(SearchString));
        }

        Employees = await query.ToListAsync();
    }
}
