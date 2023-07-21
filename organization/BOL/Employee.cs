using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        public Employee(int id, string name, string designation, string department, string city, double salary)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Department = department;
            City = city;
            Salary = salary;
        }
    }
}
