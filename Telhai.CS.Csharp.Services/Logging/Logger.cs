namespace Telhai.CS.Csharp.Services.Logging
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Exception = 3,
    }


    public class Logger : ILogger
    {
        private static Logger? _instance;
        private string _logFilePath = "";

        private Logger()
        {
        }

        private Logger(string logFilePath)
        {
            this._logFilePath = logFilePath;
        }

        public static Logger GetInstance(string path = "")
        {
            if (_instance == null)
            {
                if (string.IsNullOrEmpty(path))
                {
                    _instance = new Logger();
                }
                else
                {
                    _instance = new Logger(path);
                }
            }

            return _instance;
        }


        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        public void Log(String msg)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            Console.WriteLine(msg + ":" + formattedtime);
        }

        public void Log(String msg, LogLevel level)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            string logTxt = $"{msg} : {level} :{formattedtime}";
            Console.WriteLine(msg + ":" + level + " " + formattedtime);
        }

        // Backward-compatible static wrappers
        public static void LogStatic(string msg) => Instance.Log(msg);
        public static void LogStatic(string msg, LogLevel level) => Instance.Log(msg, level);
    }
}