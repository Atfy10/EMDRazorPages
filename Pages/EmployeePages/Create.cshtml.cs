using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementDashboard.Models;

namespace EmployeeManagementDashboard.Pages.EmployeePages;

public class CreateModel : PageModel
{
    private readonly EmployeeManagementDashboardContext _context;
    [BindProperty]
    public Employee Employee { get; set; } = default!;
    [ViewData]
    public string Title { get; } = "Create Employee";
    [ViewData]
    public string SubTitle { get; } = "Create Employee";
    [TempData]
    public string StatusMessage { get; set; } = string.Empty;

    public CreateModel(EmployeeManagementDashboardContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGet()
    {
        if (!await _context.Employees.AnyAsync())
        {
            var employees = new List<Employee>
            {
                new() { FirstName = "Ahmed", LastName = "Ali", Email = "ahmed.ali@example.com", Phone = "01000000001", Department = "Engineering", Position = Position.SoftwareEngineer, Salary = 50000, HireDate = new DateTime(2020, 3, 15), IsActive = true },
                new() { FirstName = "Sara", LastName = "Hassan", Email = "sara.hassan@example.com", Phone = "01000000002", Department = "Engineering", Position = Position.SeniorSoftwareEngineer, Salary = 80000, HireDate = new DateTime(2018, 7, 1), IsActive = true },
                new() { FirstName = "Mohamed", LastName = "Youssef", Email = "mohamed.youssef@example.com", Phone = "01000000003", Department = "Quality Assurance", Position = Position.QAEngineer, Salary = 45000, HireDate = new DateTime(2021, 1, 10), IsActive = true },
                new() { FirstName = "Noha", LastName = "Ibrahim", Email = "noha.ibrahim@example.com", Phone = "01000000004", Department = "DevOps", Position = Position.DevOpsEngineer, Salary = 75000, HireDate = new DateTime(2019, 5, 20), IsActive = true },
                new() { FirstName = "Khaled", LastName = "Mahmoud", Email = "khaled.mahmoud@example.com", Phone = "01000000005", Department = "Product", Position = Position.ProductManager, Salary = 90000, HireDate = new DateTime(2017, 11, 3), IsActive = true },
                new() { FirstName = "Mona", LastName = "Fawzy", Email = "mona.fawzy@example.com", Phone = "01000000006", Department = "Human Resources", Position = Position.HRManager, Salary = 55000, HireDate = new DateTime(2020, 8, 25), IsActive = true },
                new() { FirstName = "Omar", LastName = "Gamal", Email = "omar.gamal@example.com", Phone = "01000000007", Department = "Finance", Position = Position.Accountant, Salary = 48000, HireDate = new DateTime(2021, 4, 14), IsActive = true },
                new() { FirstName = "Dina", LastName = "Shaker", Email = "dina.shaker@example.com", Phone = "01000000008", Department = "Design", Position = Position.UXDesigner, Salary = 62000, HireDate = new DateTime(2019, 9, 8), IsActive = false },
                new() { FirstName = "Tamer", LastName = "Nabil", Email = "tamer.nabil@example.com", Phone = "01000000009", Department = "Data", Position = Position.DataAnalyst, Salary = 58000, HireDate = new DateTime(2020, 12, 1), IsActive = true },
                new() { FirstName = "Laila", LastName = "Mostafa", Email = "laila.mostafa@example.com", Phone = "01000000010", Department = "IT", Position = Position.SystemAdministrator, Salary = 52000, HireDate = new DateTime(2021, 6, 17), IsActive = true }
            };

            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();

            StatusMessage = "10 sample employees have been seeded successfully.";
        }

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            StatusMessage = "Please fill in all required fields.";
            return Page();
        }

        _context.Employees.Add(Employee);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
