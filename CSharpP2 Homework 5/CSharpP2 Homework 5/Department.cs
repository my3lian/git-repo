using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_5
{
    class Department
    {
        string name;
        public string Name { get => name; }

        List<int> employees;
        public int EmployeesCount { get => employees.Count; }

        public Department(string name)
        {
            this.name = name;
        }

        public void Add(int empID) => employees.Add(empID);
    }
}
