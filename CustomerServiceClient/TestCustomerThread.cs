using System;
using System.Collections.Generic;
using System.Threading;

namespace CustomerServiceClient
{
    class TestCustomerThread
    {
        public static void reserveSeat(string flightNumber, string seatNumber)
        {
            Console.WriteLine(String.Format("Thread {0} will reserve seat {1} in flight number {2}", Thread.CurrentThread.Name, seatNumber, flightNumber));
           
            CustomerServiceReference.CustomerClient customerClient = new CustomerServiceReference.CustomerClient();
            Console.WriteLine(customerClient.reserveSeat(flightNumber, seatNumber, "TempName", 23));
            
            Thread.Sleep(5000);

            customerClient.Close();
        }

        public static void testCustomerRole()
        {
            Console.WriteLine("Testing customer role for airline reservation service\n");
            Console.WriteLine("Starting 50 customer threads.\n");

            List<string> flightNumbers = new List<string>(new string[] {"AB10",
                "BC20","CD30","DE40","EF50","FG60","GH70","HI80",
                "IJ90","JK00"});

            List<Thread> customerThreads = new List<Thread>();

            foreach (var flightNumber in flightNumbers)
            {
                for(int i=0; i<5; i++)
                {
                    Thread customerThread = new Thread(() => reserveSeat(flightNumber,String.Format("Seat_{0}",i)));
                    customerThreads.Add(customerThread);
                    customerThread.Start();
                }
            }

            foreach (var customerThread in customerThreads)
            {
                customerThread.Join();
            }
            Console.WriteLine("All customer threads terminated. Exiting...\n");
        }
    }
}
