using System;

namespace CustomerServiceClient
{
    class Customer
    {
        private static void bookFlight(CustomerServiceReference.CustomerClient customerClient)
        {
            try
            {
                Console.WriteLine("\nEnter flight number (4 digit): ");
                string flightNumber = Console.ReadLine();
                Console.WriteLine("\nDisplaying seating chart of flight " + flightNumber + "\n");
                Console.WriteLine(customerClient.showSeatingChart(flightNumber));
                Console.WriteLine("Enter seat number in the following format \"Seat_5\": ");
                string seatNumber = Console.ReadLine();
                Console.WriteLine("Enter your name (alphabetic): ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your age (integer): ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(customerClient.reserveSeat(flightNumber, seatNumber, name, age));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            CustomerServiceReference.CustomerClient customerClient = new CustomerServiceReference.CustomerClient();

            Console.WriteLine("Welcome to Airline Reservation Service : Customer Portal");

            int choice = -1;

            while (choice != 5)
            {
                Console.WriteLine("\nSupported Operations:\n");
                Console.WriteLine("1. Show all flights\n2. Show seating chart\n3. Book a flight\n4. Run Customer Test Suite\n5. Exit\n");
                Console.WriteLine("Enter desired operation: ");
                string strChoice = Console.ReadLine();

                bool isNumeric = int.TryParse(strChoice, out choice);
                if(!isNumeric)
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n1. Show all flights\n");
                        Console.WriteLine("_______________________\n");
                        Console.WriteLine(customerClient.showAllFlights());
                        Console.WriteLine("_______________________");
                        break;
                    case 2:
                        Console.WriteLine("\n3. Show seating chart\n");
                        Console.WriteLine("Enter flight number: ");
                        string flightNo = Console.ReadLine();
                        Console.WriteLine("_______________________\n");
                        Console.WriteLine(customerClient.showSeatingChart(flightNo));
                        Console.WriteLine("_______________________\n");
                        break;
                    case 3:
                        bookFlight(customerClient);
                        break;
                    case 4:
                        Console.WriteLine("\n4. Run Customer Test Suite\n");
                        TestCustomerThread.testCustomerRole();
                        break;
                    case 5:
                        Console.WriteLine("\n5. Exit\n");
                        Console.WriteLine("Exiting Customer Portal....\n");
                        break;
                    default:
                        Console.WriteLine(String.Format("\nEntered choice {0} was not recognized", choice));
                        break;
                }

            }
            customerClient.Close();
        }
    }
}
