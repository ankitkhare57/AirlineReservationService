using System;

namespace AdministratorServiceClient
{ 
    class Administrator
    {
        private static void ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
            }
        }
        private static void addNewFlight(AdministratorServiceReference.AdministratorClient adminClient)
        {
            try
            {
                Console.WriteLine("\nEnter flight number (4 digit alphanumeric): ");
                string flightNumber = Console.ReadLine();
                Console.WriteLine("\nEnter seating capactiy (1-10): ");
                int seatCapacity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter First Class Ticket Price (Float): ");
                float firstClassPrice = Single.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Economy Class Ticket Price (Float): ");
                float economyClassPrice = Single.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter Arrival Airport (3 digit alphabetic): ");
                string arrivalAirport = Console.ReadLine();

                Console.WriteLine("\nEnter Arrival date/time in the following format \"06 July 2008 7:32:12 AM\": ");
                string arrivalTime = Console.ReadLine();
                DateTime arrivalDateTime = Convert.ToDateTime(arrivalTime);

                Console.WriteLine("\nEnter Departure Airport (3 digit alphabetic): ");
                string departureAirport = Console.ReadLine();
                
                Console.WriteLine("\nEnter Departure date/time in the following format \"06 July 2008 7:32:12 AM\": ");
                string departureTime = Console.ReadLine();
                DateTime departureDateTime = Convert.ToDateTime(departureTime);

                adminClient.createNewFlight(flightNumber, seatCapacity, firstClassPrice, economyClassPrice,
                    arrivalAirport, departureAirport, arrivalDateTime, departureDateTime);

                Console.WriteLine("\nFlight " + flightNumber + " was successfully created.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        static void Main(string[] args)
        {
            AdministratorServiceReference.AdministratorClient adminClient = new AdministratorServiceReference.AdministratorClient();
            Console.WriteLine("Welcome to Airline Reservation Service : Administrator Portal");
            
            int choice = -1;

            while(choice != 5)
            {
                Console.WriteLine("\nSupported Operations:\n");
                Console.WriteLine("1. Show all flights\n2. Add new flight\n3. Show seating chart\n4. Run Admininistrator Test Suite\n5. Exit\n");
                Console.WriteLine("Enter desired operation: ");

                string strChoice = Console.ReadLine();
                bool isNumeric = int.TryParse(strChoice, out choice);
                if (!isNumeric)
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n1. Show all flights\n");
                        Console.WriteLine("_______________________\n");
                        Console.WriteLine(adminClient.showAllFlights());
                        Console.WriteLine("_______________________");
                        break;
                    case 2:
                        Console.WriteLine("\n2. Add new flight\n");
                        addNewFlight(adminClient);
                        break;
                    case 3:
                        Console.WriteLine("\n3. Show seating chart\n");
                        Console.WriteLine("Enter flight number: ");
                        string flightNo = Console.ReadLine();
                        Console.WriteLine("_______________________\n");
                        Console.WriteLine(adminClient.showSeatingChart(flightNo));
                        Console.WriteLine("_______________________\n");
                        break;
                    case 4:
                        Console.WriteLine("4. Run Admininistrator Test Suite\n");
                        TestAdministratorThread.testAdminRole();
                        break;
                    case 5:
                        Console.WriteLine("\n5. Exit\n");
                        Console.WriteLine("Exiting Administrator Portal....\n");
                        break;
                    default:
                        Console.WriteLine(String.Format("\nEntered choice {0} was not recognized", choice));
                        break;
                }
            }

            adminClient.Close();

        }
    }
}
