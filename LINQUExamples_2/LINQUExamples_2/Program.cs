using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQUExamples_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            ///////METHOD syntax
            /*var results = employeeList.Join(departmentList, e => e.DepartmentId, d => d.Id,
                (emp, dept) => new
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    AnnualSallary = emp.AnnualSalary,
                    DepartmentId = emp.DepartmentId,
                    DepartmentName = dept.LongName
                }).OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSallary);

            foreach(var item in results)
            {
                Console.WriteLine($"First name: {item.FirstName, -10} Last Name: {item.LastName, -10} Annual Salary: {item.AnnualSallary, 10} \tDepartment Name: {item.DepartmentName}");

            }

            Console.ReadLine();
        }*/

            ////////////QUERY syntax
            /*
            var results = from emp in employeeList
                          join dept in departmentList
                          on emp.DepartmentId equals dept.Id
                          orderby emp.DepartmentId, emp.AnnualSalary descending
                          select new
                          {
                              Id = emp.Id,
                              FirstName = emp.FirstName,
                              LastName = emp.LastName,
                              AnnualSallary = emp.AnnualSalary,
                              DepartmentId = emp.DepartmentId,
                              DepartmentName = dept.LongName
                          };
            foreach (var item in results)
            {
                Console.WriteLine($"First name: {item.FirstName,-10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSallary, 10} \t Department Name: {item.DepartmentName}");
            }

            Console.ReadLine();
            }*/
            //GROUPING OPERATORS ////////////GROUP BY///////
            /*var groupResults = from emp in employeeList
                               orderby emp.DepartmentId
                               group emp by emp.DepartmentId;

            foreach (var empGroup in groupResults)
            {
                Console.WriteLine($"Department ID: {empGroup.Key}");

                foreach (Employee emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee: {emp.FirstName} {emp.LastName}");
                }
            }
            Console.ReadLine();
        }*/
            //GROUPING operators ToLoop operator////////////////
            /*var groupResults = employeeList.OrderBy(e => e.DepartmentId).ToLookup(e => e.DepartmentId);
            foreach (var empGroup in groupResults)
            {
                Console.WriteLine($"Department ID: {empGroup.Key}");

                foreach (Employee emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee: {emp.FirstName} {emp.LastName}");
                }
            }
            Console.ReadLine();
        }*/


            ///ALL, ANY, CONTAINS quantifier operators
            ///ALL and ANY operators
            /*var annualSalaryCompare = 40000;

            bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
            if (isTrueAll)
            {
                Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
            }
            else
            {
                Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
            }

            bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            if (isTrueAny)
            {
                Console.WriteLine($"At least one employee has annual salary above {annualSalaryCompare}");
            }
            else
            {
                Console.WriteLine($"No employees have annual salary above {annualSalaryCompare}");
            }

            Console.ReadLine();
}*/

            //////////Contains operator

            /* var searchEmployee = new Employee
             {
                 Id = 2,
                 FirstName = "sarah",
                 LastName = "jameson",
                 AnnualSalary = 80000.1m,
                 IsManager = true,
                 DepartmentId = 3
             };

             bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());

             if(containsEmployee)
             {
                 Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
             }
             else
             {
                 Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found");
             }*/


            ///Of TYPE filter operation

            ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //var intResult = from i in mixedCollection.OfType<int>()
            //                   select i;

            //    foreach (var item in stringResult/intResult)
            //    {
            //        Console.WriteLine(item);
            //    }



            //    var employeeResults = from e in mixedCollection.OfType<Employee>()
            //                          select e;

            //    foreach (var emp in employeeResults)
            //    {
            //        Console.WriteLine($"{emp.Id, -5} {emp.FirstName, -10} {emp.LastName, -10}");
            //    }

            //    Console.ReadLine();
            //}

            //    var departmentResults = from dept in mixedCollection.OfType<Department>()
            //                            select dept;
            //    foreach (var d in departmentResults)
            //    {
            //        Console.WriteLine($"{d.Id,-5} {d.LongName,-30} {d.ShortName,-10}");
            //    }



            //    Console.ReadLine();
            //}


            ////ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last,
            ///LastOrDefault, Single and SingleOrDefault element operator
            ///ElementAt, ElementAtOrDefault operators <summary>
            /// LastOrDefault, Single and SingleOrDefault element operator
            /// </summary>
            /*var emp = employeeList.ElementAtOrDefault(12);

            if(emp != null)
            {
                Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            }
            else
            {
                Console.WriteLine($"This employee not exist in collection");
            }

            Console.ReadLine();
        }*/

            ////Singe, SingleOrDefault operators//////
            var emp = employeeList.SingleOrDefault(e => e.Id == 11);

            if(emp != null)
            {
                Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            }
            else
            {
                Console.WriteLine("This employee does not exist within the collection");
            }

            Console.ReadLine();

        }


        public class EmployeeComparer : IEqualityComparer<Employee>
        {
            bool IEqualityComparer<Employee>.Equals(Employee? x, Employee? y)
            {
                if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
                {
                    return true;
                }
                return false;
            }

            int IEqualityComparer<Employee>.GetHashCode(Employee obj)
            {
                return obj.Id.GetHashCode();
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
                    LastName = "Jones",
                    AnnualSalary = 60000.9m,
                    IsManager = true,
                    DepartmentId = 1
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Jameson",
                    AnnualSalary = 80000.1m,
                    IsManager = true,
                    DepartmentId = 3
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 3,
                    FirstName = "Douglas",
                    LastName = "Roberts",
                    AnnualSalary = 40000.2m,
                    IsManager = false,
                    DepartmentId = 1
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Stevens",
                    AnnualSalary = 30000.2m,
                    IsManager = false,
                    DepartmentId = 3
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 5,
                    FirstName = "Sam",
                    LastName = "Smitt",
                    AnnualSalary = 60000.2m,
                    IsManager = false,
                    DepartmentId = 2
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

            public static ArrayList GetHeterogeneousDataCollection()
            {
                ArrayList arrayList = new ArrayList();

                arrayList.Add(100);
                arrayList.Add("Bob Jones");
                arrayList.Add(2000);
                arrayList.Add(3000);
                arrayList.Add("Bill Henderson");
                arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", AnnualSalary = 90000, IsManager = true, DepartmentId = 1 });
                arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
                arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
                arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
                arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

                return arrayList;


            }
        }
    }
}