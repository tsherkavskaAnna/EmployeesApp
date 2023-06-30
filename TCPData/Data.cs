using System;
using System.Collections.Generic;
namespace TCPData
{
	public static class Data
	{
		public static List<Employee> GetEmployees()
		{
			List<Employee> employees = new List<Employee>();

			Employee employee = new Employee
			{
				Id = 1,
                FirstName = "Bob",
				LastName = "Johnes",
				AnnualSalary = 60000.9m,
				IsManager = true,
				DepartmentId = 1
			};
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sara",
                LastName = "Still",
                AnnualSalary = 54673.8m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Billy",
                LastName = "Dickson",
                AnnualSalary = 7050.9m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jessica",
                LastName = "Stevens",
                AnnualSalary = 39770.9m,
                IsManager = false,
                DepartmentId = 3
            };

            employees.Add(employee);
            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);
            return departments;
        }
	}
}

