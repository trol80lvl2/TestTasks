using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestTAsk
{
    public interface ICommandParser
    {
        public string[] Parse(string str);
        public bool TryParse(string str, out string[] strArr);
    }
}
