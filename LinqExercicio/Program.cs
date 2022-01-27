using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using LinqExercicio.Entities;

namespace LinqExercicio {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            List<Employee> emp = new List<Employee>();
            Console.Write("Enter Salary: ");
            double salarySearch = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            using(StreamReader sr = File.OpenText(path)) {
                while(!sr.EndOfStream) {
                    string[] vect = sr.ReadLine().Split(",");
                    string name = vect[0];
                    string email = vect[1];
                    double salary = double.Parse(vect[2], CultureInfo.InvariantCulture);
                    emp.Add(new Employee(name, email, salary));


                    }
                var peopleSalary = emp.Where(p => p.Salary>salarySearch).OrderBy(p => p.Email).Select(p => p.Email);
                Console.WriteLine("Email of people whose salary is more than "+salarySearch.ToString("F2", CultureInfo.InvariantCulture));
                foreach(string emails in peopleSalary) {
                    Console.WriteLine(emails);
                    }
                var sumSalary = emp.Where(p => p.Name[0]=='M').Select(p => p.Salary).Sum();
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumSalary);
                }
            }
        }
    }
