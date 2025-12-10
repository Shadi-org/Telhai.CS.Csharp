using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.Csharpproject._01Practice.Logger
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Exception = 3,
    }
    public class Logger
    {
        public static void log(String msg)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            Console.WriteLine(msg + ":" + formattedtime);
        }
        public static void log(String msg, LogLevel level)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            string logTxt = $"{msg} : {level} :{formattedtime}";
            Console.WriteLine(msg + ":" + level + " " + formattedtime);
        }
    }
}