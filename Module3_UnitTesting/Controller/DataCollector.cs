using Module3_UnitTesting.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_UnitTesting.Controller
{
    public class DataCollector
    {
        readonly ConsoleUI _consoleUI;

        public DataCollector(ConsoleUI consoleUI = null)
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

        ConsoleUI consoleUI {
            get { return _consoleUI; }
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
            date = new DateTime();

            bool invalidData = true;
            do
            {
                try
                {
                    consoleUI.WriteLine(prompt);
                    date = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    consoleUI.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("date: {0}", date);
                invalidData = false;
            } while (invalidData && required);
        }
    }
}
