using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSUBeatmapTool.Lib
{
    public static class Log
    {
        private static LogManager logManager;
        static Log()
        {
            logManager = new LogManager();
        }

        public static void WriteLog(LogFile logFile, string msg)
        {
            logManager.WriteLog(logFile, msg);
        }

        public static void WriteLog(string logFile, string msg)
        {
            logManager.WriteLog(logFile, msg);
        }
    }
}
