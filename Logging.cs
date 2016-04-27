using System;
using System.IO;

namespace LibCore
{
    public class Logging
    {
        bool logToFile = false;
        string logname = "";

        public Logging(string logname, bool deleteLog, bool logToFile)
        {
            this.logname = logname;
            this.logToFile = logToFile;

            if (deleteLog)
            {
                File.Delete(logname);
            }
        }

        public void Info(string message)
        {
            message = string.Format("INFO: {0}", message);

            Display(message);
        }

        public void Warning(string message)
        {
            message = string.Format("WARNING: {0}", message);

            Display(message);
        }

        public void Error(string message)
        {
            message = string.Format("ERROR: {0}", message);

            Display(message);
        }

        public void Task(string message)
        {
            message = string.Format("TASK: {0}", message);

            Display(message);
        }

        private void Display(string message)
        {
            Console.WriteLine(message);

            if (logToFile)
            {
                File.AppendAllLines(logname, new string[] { message });
            }
        }
    }
}