using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClient
{
    class Customer
    {
        static void Main(string[] args)
        {
            CustomerServiceReference.CustomerClient customerClient = new CustomerServiceReference.CustomerClient();

            Console.WriteLine(customerClient.showAllFlights());
            Console.WriteLine(customerClient.showSeatingChart("abc"));
            Console.WriteLine("Press enter to close client");
            Console.ReadLine();
            customerClient.Close();

        }
    }
}
