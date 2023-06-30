using System;
using System.Collections.Generic;
using TCPData;
using TCPExrentions;

namespace ThePretendCompany
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            var resultList = from emp in employeeList
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach(var employee in resultList)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.Manager}");
                Console.WriteLine($"Deparment: {employee.Department}");
                Console.WriteLine();
            }

            var averageAnnualSalary = resultList.Average(av => av.AnnualSalary);
            var hightesAnnulaSalary = resultList.Max(av => av.AnnualSalary);
            var lowestAnnualSalary = resultList.Min(av => av.AnnualSalary);

            Console.WriteLine($"Media salary: {averageAnnualSalary}");
            Console.WriteLine($"Max salary: {hightesAnnulaSalary}");
            Console.WriteLine($"Min salary: {lowestAnnualSalary}");

            Console.ReadKey();

        }
    }
}

