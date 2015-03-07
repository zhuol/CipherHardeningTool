using System;
using System.IO;

namespace CipherHardeningTool
{
    public static class Log
    {
        private static readonly string Path = Directory.GetCurrentDirectory() + "\\CipherHardeningTool.log";

        public static void LogMessageToFile(string msg)
        {
            var sw = File.AppendText(Path);
            try
            {
                var logLine = String.Format("{0:G}: {1}.", DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }

        public static void LogErrorToFile(string msg, Exception e)
        {
            var sw = File.AppendText(Path);
            try
            {
                var logLine = String.Format("{0:G}: {1}.\n{2}\n{3}", DateTime.Now, msg, e.Message, e.StackTrace);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
