using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringNetStandard;

namespace ConsoleAppOLTPNet48
{
    internal class Program
    {
        public static void Main()
        {
            Monitor.Create(); 

            using (var activity = Monitor.MyActivitySource.StartActivity("SayHelloToConsole"))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("bar", "Hello, World!");
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            //// Dispose tracer provider before the application ends.
            //// This will flush the remaining spans and shutdown the tracing pipeline.
            Console.ReadKey();
            Monitor.TracerProvider.Dispose();
        }
    }
}
