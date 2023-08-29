using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.model
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Email { get; set; }
        [Required]
        public Departments? Department { get; set; }
        
        public string? PhotoLocation { get; set; }

    }
}
