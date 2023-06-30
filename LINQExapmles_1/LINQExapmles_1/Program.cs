using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExapmles_1;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employeeList = Data.GetEmployees();
        List<Department> departmentList = Data.GetDepartments();

        ///////////SELECT and WHERE operators - METHOD syntax
        /*var results = employeeList.Select(e => new
        {
            FullName = e.FirstName + " " + e.LastName,
            AnnnualSalary = e.AnnualSalary
        }).Where(e => e.AnnnualSalary >= 20000);

        foreach (var item in results)
        {
            Console.WriteLine($"{item.FullName, -20} {item.AnnnualSalary, 10}");
        }*/

        ////////////// SELECT and WHERE operators - QUERY syntax
        /*var results = from emp in employeeList
                      where emp.AnnualSalary > 20200
                      select new
                      {
                          FullName = emp.FirstName + " " + emp.LastName,
                          AnnualSalary = emp.AnnualSalary
                      };
        foreach (var item in results)
            {
                Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            }*/

        /////////Deferred Execution example using class down
        /*var results = from emp in employeeList.GetHighSalariedEmployees()
                      select new
                      {
                          FullName = emp.FirstName + emp.LastName,
                          AnnualSalary = emp.AnnualSalary
                      };

            employeeList.Add(new Employee
            {
                Id = 5,
                FirstName = "Adam",
                LastName = "Davis",
                AnnualSalary = 80000.9m,
                IsManager = true,
                DepartmentId = 3
            });

        foreach (var item in results)
        {
            Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
        }
    }
}*/

        ///////////// JOIN operator - METHOD syntax
        /*var results = departmentList.Join(employeeList, 
            department => department.Id,
            employee => employee.DepartmentId,
            (department, employee) => new
            {
                FullName = employee.FirstName + " " + employee.LastName,
                AnnualSalary = employee.AnnualSalary,
                departmentName = department.LongName
            });

        foreach (var item in results)
        {
            Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.departmentName}");
        }

        Console.ReadKey();

    }
}*/
        /// ////Immediate Execution Example
        /* var results = (from emp in employeeList.GetHighSalariedEmployees()
                        select new
                        {
                            FullName = emp.FirstName + " " + emp.LastName,
                            AnnualSalary = emp.AnnualSalary
                        }).ToList();

         employeeList.Add(new Employee
         {
             Id = 5,
             FirstName = "Sam",
             LastName = "Davis",
             AnnualSalary = 100000.20m,
             IsManager = true,
             DepartmentId = 2

         });

         foreach (var item in results)
         {
             Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
         }
     }
 }*/

        /////////////////JOIN operation example - QUERY syntax

        //        var results = from dept in departmentList
        //                      join emp in employeeList
        //                      on dept.Id equals emp.DepartmentId
        //                      select new
        //                      {
        //                          FullName = emp.FirstName + " " + emp.LastName,
        //                          AnnualSalary = emp.AnnualSalary,
        //                          DepartmentName = dept.LongName
        //                      };

        //        foreach (var item in results)
        //        {
        //            Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
        //        }

        //        Console.ReadKey();
        //    }
        //}

        //GROUP JOIN operator example - METHOD syntax

        /*var results = departmentList.GroupJoin(employeeList,
            dept => dept.Id,
            emp => emp.DepartmentId,
            (dept, employeesGroup) => new
            {
                Employees = employeesGroup,
                DepartmentName = dept.LongName
            }
            );
        foreach (var item in results)
        {
            Console.WriteLine($"Department name : {item.DepartmentName}");
            foreach (var emp in item.Employees)
                Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
        }

        Console.ReadLine();
        }
        }*/

        ///////////////GROUP JOIN operator example - QUERY syntax

        var results = from dept in departmentList
                      join emp in employeeList
                      on dept.Id equals emp.DepartmentId
                      into employeerGroup
                      select new
                      {
                          Employees = employeerGroup,
                          DepartmentName = dept.LongName
                      };

        foreach (var item in results)
        {
            Console.WriteLine($"Department name : {item.DepartmentName}");
            foreach (var emp in item.Employees)
                Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
        }

        Console.ReadLine();
    }
}
//class 
public static class EnumerableCollectionExtensionmethods
{
    public static IEnumerable<Employee>GetHighSalariedEmployees(this IEnumerable<Employee> employees)
    {
        foreach (Employee emp in employees)
        {
            Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

            if (emp.AnnualSalary >= 50000)
                yield return emp;
        }
    }
}


    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
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
                AnnualSalary = 70500.9m,
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


