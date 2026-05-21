using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementDashboard.Models
{
    public class EmployeeManagementDashboardContext : DbContext
    {
        public EmployeeManagementDashboardContext(DbContextOptions<EmployeeManagementDashboardContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
