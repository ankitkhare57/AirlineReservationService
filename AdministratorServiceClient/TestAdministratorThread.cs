using System;
using System.Collections.Generic;
using System.Threading;

namespace AdministratorServiceClient
{
    class TestAdministratorThread
    {
        public static void addNewFlight(string flightNumber)
        {
            Console.WriteLine(String.Format("Thread {0} will create flight number {1}", Thread.CurrentThread.Name, flightNumber));

            DateTime arrivalTime = new DateTime(2008, 1, 1, 12, 0, 0);
            DateTime departureTime = new DateTime(2008, 1, 1, 10, 0, 0);
            AdministratorServiceReference.AdministratorClient adminClient = new AdministratorServiceReference.AdministratorClient();
            Console.WriteLine(adminClient.createNewFlight(flightNumber, 5, 100, 50, "asd", "xyz", arrivalTime, departureTime));
            Thread.Sleep(5000);
            adminClient.Close();
        }

        public static void testAdminRole()
        {
            Console.WriteLine("Testing administrator role for airline reservation service\n");
            Console.WriteLine("Starting 10 administrator threads.\n");
            
            List<string> flightNumbers = new List<string>(new string[] {"AB10",
                "BC20","CD30","DE40","EF50","FG60","GH70","HI80",
                "IJ90","JK00"});

            List<Thread> adminThreads = new List<Thread>();

            foreach(var flightNumber in flightNumbers)
            {
                Thread adminThread = new Thread(() => addNewFlight(flightNumber));
                adminThreads.Add(adminThread);
                adminThread.Start();
            }

            foreach(var adminThread in adminThreads)
            {
                adminThread.Join();
            }
            Console.WriteLine("All administrator threads terminated. Exiting...\n");
        }
    }
}
