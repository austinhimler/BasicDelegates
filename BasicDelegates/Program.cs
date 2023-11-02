using System;
using System.IO;

namespace BasicDelegates
{
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();

            LogDel logTextToScreenDel, logTextToFileDel;

            logTextToScreenDel = new LogDel(log.LogTextToScreen);
            logTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = logTextToScreenDel + logTextToFileDel;

            Console.WriteLine("Please input your name...");

            var n = Console.ReadLine();

            LogText(multiLogDel, n);

            Console.ReadKey();
           }
        
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        { 
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}