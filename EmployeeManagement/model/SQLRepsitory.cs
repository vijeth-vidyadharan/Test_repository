                                                 using EmployeeManagement.model.Context;

namespace EmployeeManagement.model
{
    public class SQLRepsitory : IEmployeeRepository
    {
        private readonly EmployeeContext context;
        public SQLRepsitory(EmployeeContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee em = context.employees.FirstOrDefault(e => e.Id == id);
            if (em != null)
            {
                context.employees.Remove(em);
                context.SaveChanges();
            }
            return em;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.employees;
        }

        Employee IEmployeeRepository.GetEmployee(int id)
        {
            Employee em = context.employees.FirstOrDefault(e => e.Id == id);
            
            return em;
        }

        Employee IEmployeeRepository.Update(Employee employee)
        {
            var emp1 = context.employees.Attach(employee);
            emp1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
