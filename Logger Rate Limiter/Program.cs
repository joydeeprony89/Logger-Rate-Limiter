using System;
using System.Collections.Generic;

namespace Logger_Rate_Limiter
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new Logger();
            Console.WriteLine(log.ShouldPrintMessage(1, "foo"));
            Console.WriteLine(log.ShouldPrintMessage(2, "bar"));
            Console.WriteLine(log.ShouldPrintMessage(3, "foo"));
            Console.WriteLine(log.ShouldPrintMessage(8, "bar"));
            Console.WriteLine(log.ShouldPrintMessage(10, "foo"));
            Console.WriteLine(log.ShouldPrintMessage(11, "foo")); 
        }

        public class Logger
        {
            Dictionary<string, int> hash;
            /** Initialize your data structure here. */
            public Logger()
            {
                hash = new Dictionary<string, int>();
            }

            /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
                If this method returns false, the message will not be printed.
                The timestamp is in seconds granularity. */
            public bool ShouldPrintMessage(int timestamp, string message)
            {
                if (!hash.ContainsKey(message))
                {
                    hash.Add(message, timestamp);
                    return true;
                }

                int lasttime = hash[message];
                if (timestamp - lasttime >= 10)
                {
                    hash[message] = timestamp;
                    return true;
                }

                return false;
            }
        }
    }
}
