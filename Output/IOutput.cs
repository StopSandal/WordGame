using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Output
{
    internal interface IOutput
    {
        public void WriteLine(string line);
        public void WriteLine();
        public void Write(string line);
        public string ReadLine();
        public void Clear();
        public (int left, int top) GetCursorPosition();
        public void SetCursorPosition(int left, int top);
    }
}
