using System;
using System.Diagnostics;

namespace RemoveEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (EventLog.Exists(args[0]))
                {
                    try
                    {
                        EventLog.Delete(args[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(string.Format("Unable to remove Event Log '{0}'.\n\n {1}", args[0], e.Message));
                    }
                }
                else
                    Console.WriteLine(string.Format("Event Log '{0}' does not exist", args[0]));
            }
            else
                Console.WriteLine("Usage: RemoveEventLog \"EventLog\"");
        }
    }
}
