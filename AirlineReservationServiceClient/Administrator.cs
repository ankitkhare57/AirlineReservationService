using System;

namespace AirlineReservationServiceClient
{
    class Administrator
    {
        static void Main(string[] args)
        {
            AdministratorServiceReference.AdministratorClient adminClient = new AdministratorServiceReference.AdministratorClient();
            var date1 = new DateTime(2008, 1, 5, 7, 23, 23);
            var date2 = new DateTime(2009, 1, 5, 7, 23, 23);
            string test = adminClient.createNewFlight("abcd", 5, 1000, 10, "ind", "usa", date2, date1);
            Console.WriteLine(test);
            test = adminClient.createNewFlight("xyza", 5, 1000, 10, "ind", "usa", date2, date1);
            Console.WriteLine(test);
            Console.WriteLine(adminClient.showSeatingChart("abcd"));
            Console.WriteLine("Press enter to close client");
            Console.ReadLine();
            adminClient.Close();

        }
    }
}
