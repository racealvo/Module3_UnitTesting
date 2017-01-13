using System;
using Module3_UnitTesting.Controller;
using Module3_UnitTesting.View;

namespace Module3_UnitTesting.Controller
{
    public abstract class BiographicInfo
    {
        readonly IDataCollector _dc;
        readonly IUserInterface _console;

        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        protected string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        protected string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        protected DateTime BirthDate 
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public abstract string BioType { get; }

        public BiographicInfo(DataCollector dc = null, IUserInterface ui = null) {
            _dc = (dc == null) ? new DataCollector() : dc;
            _console = (ui == null) ? new ConsoleUI() : ui;

            //I am using the field names rather than create local variables and then having to assign the properties (extra steps)
            Input(out _firstName, out _lastName, out _birthDate);
            Output(_firstName, _lastName, _birthDate.ToString());
        }

        IDataCollector dc { get { return _dc; } }
        IUserInterface console { get { return _console; } }
        
        /// <summary>
        /// Get biographic information (student or teacher) - name, birthdate, address
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthDate"></param>
        protected void Input(out string firstName, out string lastName, out DateTime birthDate)
        {
            dc.GetStringData("Enter the " + BioType + "'s first name (REQUIRED): ", out firstName);
            dc.GetStringData("Enter the " + BioType + "'s last name (REQUIRED): ", out lastName);
            dc.GetDate("Enter the " + BioType + "'s birth date (REQUIRED): ", out birthDate);
        }

        /// <summary>
        /// Print biographic information (student or teacher)
        /// </summary>
        /// <param name="bioType"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="birthDate"></param>
        protected void Output(string first, string last, string birthDate)
        {
            console.WriteLine(string.Format("{0}: {1} {2} was born on: {3}", BioType, first, last, birthDate));
            console.WriteLine("\n\n");
        }
    }
}
