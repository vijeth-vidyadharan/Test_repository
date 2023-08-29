﻿namespace EmployeeManagement.model
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee (int id);

        IEnumerable<Employee> GetAllEmployee();
        Employee Add (Employee employee);
        Employee Update (Employee employee);
        Employee Delete (int id);
    }
}
