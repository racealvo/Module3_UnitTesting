using Module3_UnitTesting.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_UnitTesting.Controller
{
    public interface IDataCollector
    {
        void GetStringData(string prompt, out string data, bool required = true);
        void GetDate(string prompt, out DateTime date, bool required = true);
    }

    public class DataCollector : IDataCollector
    {
        private IUserInterface _consoleUI = null;

        IUserInterface consoleUI
        {
            get { return _consoleUI; }
            set { _consoleUI = value; }
        }

        public DataCollector(IUserInterface consoleUI = null)
        {
            if (consoleUI == null)
            {
                _consoleUI = new ConsoleUI();
            }
            else
            {
                _consoleUI = consoleUI;
            }
        }

        /// <summary>
        /// Get string data from the user.  If the data is required, keep looping until we get something legitimate.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="data"></param>
        /// <param name="required"></param>
        public void GetStringData(string prompt, out string data, bool required = true)
        {
            do
            {
                consoleUI.WriteLine(prompt);
                data = consoleUI.ReadLine();
            } while (required && (string.IsNullOrWhiteSpace(data)));
        }

        public void GetDate(string prompt, out DateTime date, bool required = true)
        {
            string userInput = string.Empty;
            date = new DateTime();

            bool invalidData = true;
            do
            {
                try
                {
                    consoleUI.WriteLine(prompt);
                    userInput = consoleUI.ReadLine();
                    //date = Convert.ToDateTime(userInput);
                    date = DateTime.Parse(userInput);
                }
                catch (Exception e)
                {
                    consoleUI.WriteLine(userInput + ": " + e.Message);
                    continue;
                }
                consoleUI.WriteLine("date: " + date);
                invalidData = false;
            } while (invalidData && required);
        }
    }
}
