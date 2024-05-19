using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Output
{
    internal class ConsoleOutput : IOutput
    {
        public void Clear()
        {
            Console.Clear();
        }

        public (int left, int top) GetCursorPosition()
        {
            return Console.GetCursorPosition();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public void Write(string line)
        {
            Console.Write(line);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
