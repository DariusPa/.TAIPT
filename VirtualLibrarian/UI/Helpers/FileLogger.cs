using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Helpers
{
    public class FileLogger : ILogger
    {
        public string LogFile { get; set; }

        public FileLogger()
        {
            LogFile = StringConstants.LogFile;
        }

        public void Log(string type,string msg)
        {
            using (StreamWriter streamWriter = new StreamWriter(LogFile))
            {
                streamWriter.WriteLine($"{DateTime.Now} {type}: {msg}");
                streamWriter.Close();
            }
        }

        public void LogError(string msg)
        {
            Log("ERROR", msg);
        }

        public void LogException(Exception ex)
        {
            Log(ex.GetType().Name, ex.Message + ex.StackTrace );
        }

        public void LogInfo(string msg)
        {
            Log("INFO", msg);
        }

        public void LogWarning(string msg)
        {
            Log("WARNING", msg);
        }
    }
}
