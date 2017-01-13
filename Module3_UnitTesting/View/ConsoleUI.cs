using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_UnitTesting.View
{
    public interface IUserInterface
    {
        string ReadLine();
        void WriteLine(string s);
    }

    public class ConsoleUI : IUserInterface
    {
        public virtual string ReadLine()
        {
            return  Console.ReadLine();
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
    }
}
