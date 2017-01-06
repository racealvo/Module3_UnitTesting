using System;
using Module3_UnitTesting.Controller;
using Module3_UnitTesting.View;

namespace Module3_UnitTesting.Controller
{
    public class BiographicInfo
    {
        readonly DataCollector _dc;
        readonly ConsoleUI _console;

        public BiographicInfo() {
            _dc = new DataCollector();
            _console = new ConsoleUI();
        }

        DataCollector dc { get { return _dc; } }
        ConsoleUI console { get { return _console; } }
        
        /// <summary>
        /// Get biographic information (student or teacher) - name, birthdate, address
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        protected void Input(string bioType, out string firstName, out string lastName, out DateTime birthDate)
        {
            dc.GetStringData("Enter the " + bioType + "'s first name (REQUIRED): ", out firstName);
            dc.GetStringData("Enter the " + bioType + "'s last name (REQUIRED): ", out lastName);
            dc.GetDate("Enter the " + bioType + "'s birth date (REQUIRED): ", out birthDate);
        }

        /// <summary>
        /// Print biographic information (student or teacher)
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="birthDate"></param>
        protected void Output(string bioType, string first, string last, string birthDate)
        {
            console.WriteLine(string.Format("{0}: {1} {2} was born on: {3}", bioType, first, last, birthDate));
            console.WriteLine("\n\n");
        }
    }
}
