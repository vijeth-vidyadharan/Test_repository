using EmployeeManagement.model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeCreateViewModel
    {

        
        [Required]
        public string Name { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public Departments? Department { get; set; }
        
        public IFormFile PhotoLocation { get; set; }
    }
}
