using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadawansTask13
{
    class Employee
    {
        string surname;
        private int age;

        public Employee()
        {
            surname = string.Empty;
        }
        public Employee(string surname, int age)
        {
            this.surname = surname;
            this.age = age;
        }

        private string ReturnAgeValue()
        {
            return age.ToString();
        }

        public void ChangeSurname(string newsurname)
        {
            surname = newsurname; 
        }

        public string ReturnEmployeeInfo()
        {
            string info = String.Concat("Surname: ", surname, ", Age: ", age);
            return info;
        }
    }
}
