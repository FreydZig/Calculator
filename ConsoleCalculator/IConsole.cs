using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IConsole
    {
        void WriteLine(string input);
        void WriteLine(string input, params object[] args);
        void Write(string input);
        string ReadLine();
    }

    public class DefaultConsole : IConsole
    {
        public string ReadLine() => Console.ReadLine();

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteLine(string input, params object[] args)
        {
            Console.WriteLine(input, args);
        }
    }
}
