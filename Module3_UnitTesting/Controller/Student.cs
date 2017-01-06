using System;

namespace Module3_UnitTesting.Controller
{
    public class Student : BiographicInfo
    {
        public Student()
        {
            string firstName;
            string lastName;
            DateTime birthDate;

            Input("x", out firstName, out lastName, out birthDate);
            Output("x", firstName, lastName, birthDate.ToString());
        }
    }
}
