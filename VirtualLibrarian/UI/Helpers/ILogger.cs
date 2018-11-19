using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Helpers
{
    public interface ILogger
    {
        void LogInfo (string msg);
        void LogError(string msg);
        void LogWarning(string msg);
        void LogException(Exception ex);
    }
}
