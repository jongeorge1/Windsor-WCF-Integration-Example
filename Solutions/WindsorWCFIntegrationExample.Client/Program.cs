namespace WindsorWCFIntegrationExample.Client
{
    using System.Diagnostics;
    using System;
    using Castle.Facilities.WcfIntegration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Core.Contracts;

    class Program
    {
        static void Main()
        {
            const int TotalCallsToMake = 1000;

            // Configure standard DI container to use *.Infrastructure implementation of ICustomerService
            var container = new WindsorContainer("Configuration/Windsor.config");

            // Configure DI Container to resolve ICustomerService against WCF implementation
            var containerDistributed = new WindsorContainer()
                                            .AddFacility<WcfFacility>()
                                            .Install(Configuration.FromXmlFile("Configuration/WindsorWCF.config"));

            var customerTasks = container.Resolve<ICustomerTasks>();
            var customerTasksDistributed = containerDistributed.Resolve<ICustomerTasks>();

            Console.WriteLine("Press Any Key to run test.");
            Console.ReadKey();

            Console.WriteLine("First In Process Call:" + Environment.NewLine);

            long inProcessExecutionTime = GetCallTime(customerTasks);

            Console.WriteLine("First In Process Call complete, took " + inProcessExecutionTime + "ms." + Environment.NewLine);

            Console.WriteLine("First Out of Process Call:" + Environment.NewLine);

            long outOfProcessExecutionTime = GetCallTime(customerTasksDistributed);

            Console.WriteLine("First Out of Process Call complete, took " + outOfProcessExecutionTime + "ms." + Environment.NewLine);

            Console.WriteLine();
            Console.WriteLine("Executing {0} in process calls", TotalCallsToMake);

            inProcessExecutionTime = GetAverageCallTime(customerTasks, TotalCallsToMake);

            Console.WriteLine("Finished executing {0} in process calls; average execution time is {1}", TotalCallsToMake, inProcessExecutionTime);

            Console.WriteLine();
            Console.WriteLine("Executing {0} out of process calls", TotalCallsToMake);

            inProcessExecutionTime = GetAverageCallTime(customerTasksDistributed, TotalCallsToMake);

            Console.WriteLine("Finished executing {0} out of process calls; average execution time is {1}", TotalCallsToMake, inProcessExecutionTime);
            
            Console.WriteLine("Press Any Key to Quit.");
            Console.ReadKey();
        }

        private static long GetCallTime(ICustomerTasks customerTasks)
        {
            var callStopwatch = new Stopwatch();
            
            callStopwatch.Start();

            customerTasks.DoTask();

            callStopwatch.Stop();

            return callStopwatch.ElapsedMilliseconds;
        }

        public static long GetAverageCallTime(ICustomerTasks customerTasks, int numberOfCallsToMake)
        {
            long totalMilliseconds = 0;

            for (int index = 0; index < numberOfCallsToMake; index++)
            {
                totalMilliseconds += GetCallTime(customerTasks);
            }

            return totalMilliseconds / numberOfCallsToMake;
        }
    }
}