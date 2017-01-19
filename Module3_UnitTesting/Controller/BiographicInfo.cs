using System;
using Module3_UnitTesting.Controller;
using Module3_UnitTesting.View;

namespace Module3_UnitTesting.Controller
{
    public interface IBiographicInfo
    {
        IDataCollector DataCollect { get; set; }
        string FirstName { get; }
        string LastName { get; }
        DateTime BirthDate { get; }

        void RunIO();
        void Input();
        void Output();
    }

    public class BiographicInfo : IBiographicInfo
    {
        public IDataCollector DataCollect { get; set; }
        public IUserInterface Console { get; set; }

        public BiographicInfo()
        {
            // set defaults
            DataCollect = new DataCollector();
            Console = new ConsoleUI();
        }

        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime BirthDate 
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string BioType { get; set; }

        public void RunIO() {
            Input();
            Output();
        }

        /// <summary>
        /// Get biographic information (student or teacher) - name, birthdate, address
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        public void Input()
        {
            string s;
            DateTime t;

            FirstName = DataCollect.GetStringData("Enter the " + BioType + "'s first name (REQUIRED): ", out s);
            LastName = DataCollect.GetStringData("Enter the " + BioType + "'s last name (REQUIRED): ", out s);
            BirthDate = DataCollect.GetDate("Enter the " + BioType + "'s birth date (REQUIRED): ", out t);
        }

        /// <summary>
        /// Print biographic information (student or teacher)
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="birthDate"></param>
        public void Output()
        {
            Console.WriteLine(string.Format("{0}: {1} {2} was born on: {3}", BioType, FirstName, LastName, BirthDate));
            Console.WriteLine("\n\n");
        }
    }
}
