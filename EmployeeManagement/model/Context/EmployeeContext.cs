using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.model.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext( DbContextOptions<EmployeeContext> options) :base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}
