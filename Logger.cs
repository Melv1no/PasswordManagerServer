using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    internal class Logger
    {
        public static Logger Instance { get; private set; }
        public static void log(string message)
        {
            Console.WriteLine(message);
        }
        public static void log(ConsoleColor consoleColor,string message)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[INFO] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[DEBUG] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public const string
            ERROR_ARGS_NO_FOUND = "Args no found",
            ERROR_ARGS_NEEDED = "";
    }
}
