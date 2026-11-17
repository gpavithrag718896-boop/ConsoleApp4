
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Arun", Department = "IT", Age = 28, Salary = 60000 },
            new Employee { Id = 2, Name = "Priya", Department = "HR", Age = 32, Salary = 35000 },
            new Employee { Id = 3, Name = "Kumar", Department = "Finance", Age = 36, Salary = 50000 },
            new Employee { Id = 4, Name = "Divya", Department = "IT", Age = 34, Salary = 75000 },
            new Employee { Id = 5, Name = "Ravi", Department = "HR", Age = 29, Salary = 28000 },
            new Employee { Id = 6, Name = "Meena", Department = "Finance", Age = 31, Salary = 42000 },
            new Employee { Id = 7, Name = "Karthik", Department = "IT", Age = 30, Salary = 55000 },
            new Employee { Id = 8, Name = "Sneha", Department = "Finance", Age = 27, Salary = 38000 }
        };

        


        Console.WriteLine("\n1. IT Employees Salary > 50000");

        var q1 = from e in employees
                 where e.Department == "IT" && e.Salary > 50000
                 select e;

        foreach (var e in q1)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }

        
        var m1 = employees.Where(e =>
            e.Department == "IT" && e.Salary > 50000);

        Console.WriteLine("\nMethod Syntax");

        foreach (var e in m1)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }


       
        Console.WriteLine("\n2. Sort by Salary - Query Syntax");

        var q2 = from e in employees
                 orderby e.Salary
                 select e;

        foreach (var e in q2)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }

        

        Console.WriteLine("\nSort by Salary - Method Syntax");

        var m2 = employees.OrderBy(e => e.Salary);

        foreach (var e in m2)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }


       
        Console.WriteLine("\n3. Group By Department - Query Syntax");

        var q3 = from e in employees
                 group e by e.Department;

        foreach (var group in q3)
        {
            Console.WriteLine("\nDepartment: " + group.Key);

            foreach (var e in group)
            {
                Console.WriteLine(e.Name);
            }
        }

        
        Console.WriteLine("\nGroup By Department - Method Syntax");

        var m3 = employees.GroupBy(e => e.Department);

        foreach (var group in m3)
        {
            Console.WriteLine("\nDepartment: " + group.Key);

            foreach (var e in group)
            {
                Console.WriteLine(e.Name);
            }
        }


       

        Console.WriteLine("\n4. Average Salary - Query Syntax");

        var q4 = from e in employees
                 group e by e.Department into dept
                 select new
                 {
                     Department = dept.Key,
                     AverageSalary = dept.Average(e => e.Salary)
                 };

        foreach (var d in q4)
        {
            Console.WriteLine(d.Department + " - " + d.AverageSalary);
        }

       

        Console.WriteLine("\nAverage Salary - Method Syntax");

        var m4 = employees.GroupBy(e => e.Department)
                          .Select(g => new
                          {
                              Department = g.Key,
                              AverageSalary = g.Average(e => e.Salary)
                          });

        foreach (var d in m4)
        {
            Console.WriteLine(d.Department + " - " + d.AverageSalary);
        }

        Console.ReadLine();
    }
}
