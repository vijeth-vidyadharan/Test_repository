namespace EmployeeManagement.model
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees = new();

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>() { new Employee() 
            { Id= 1 ,Name="Rahul" , Email="rahul@gamil",Department=Departments.CS} ,
            new Employee()
            { Id= 2 ,Name="Raju" , Email="raju@gamil",Department=Departments.EEE} ,
            new Employee()
            { Id= 3 ,Name="Raman" , Email="raman@gamil",Department=Departments.NONE} ,};
        }
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employees;
        }

        public Employee Add(Employee employee)
        {
            employee.Id= _employees.Max(e => e.Id)+1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            Employee em = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (em != null)
            {
               em.Email = employee.Email;
                em.Department = employee.Department;
                em.Name = employee.Name;
            }
            return em;
        }

        public Employee Delete(int id)
        {
            Employee em = _employees.FirstOrDefault(e => e.Id==id);
            if (em!=null)
            {
                _employees.Remove(em);
            }
            return em;

        }
    }
}
