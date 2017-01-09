using Module3_UnitTesting.Controller;
using Module3_UnitTesting.View;

namespace Module3_UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI console = new ConsoleUI();

            Student student = new Student();
            Teacher teacher = new Teacher();

            console.WriteLine("Press any key to terminate.");
            console.ReadLine();
        }
    }
}
