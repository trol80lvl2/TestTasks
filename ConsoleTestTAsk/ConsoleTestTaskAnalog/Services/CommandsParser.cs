using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestTAsk
{
    public class CommandsParser : ICommandParser
    {
        public string[] Parse(string str)
        {
            string[] tempArr = str.Split(' ');
            return tempArr;
        }

        public bool TryParse(string str, out string[] strArr)
        {
            strArr = Parse(str);
            return strArr[0] == "add" || strArr[0] == "remove" || strArr[0] == "download";
        }
    }
}
