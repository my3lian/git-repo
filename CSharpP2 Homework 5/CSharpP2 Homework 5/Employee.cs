using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_5
{
    class Employee
    {
        string name;
        string surname;
        string patronymic;
        int depID;
        static int currentID = 0;
        int id;
        public int ID { get => id; }

        public string FullName { get => $"{name} {surname} {patronymic}"; }

        public void AssignToDep(int depID) => this.depID = depID;

        public Employee(string name, string surname, string patronymic) {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            id = currentID++;
        }

    }
}
