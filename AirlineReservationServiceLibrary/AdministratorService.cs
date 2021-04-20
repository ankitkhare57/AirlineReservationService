using System;

namespace AirlineReservationServiceLibrary
{
    public class AdministratorService : IAdministrator
    {

        public string createNewFlight(string flightNumber, int seatCapacity,
            float firstClassPrice, float economyClassPrice,
            string arrivalAirport, string departureAirport,
            DateTime arrivalTime, DateTime departureTime)
        {
            try {
                Flight newFlight = new Flight(flightNumber, seatCapacity,
                firstClassPrice, economyClassPrice,
                arrivalAirport, departureAirport,
                arrivalTime, departureTime);

                FlightDB.addFlight(newFlight);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            return "Created flight: "+flightNumber;
        }

        public string showAllFlights()
        {
            return FlightDB.showAllFlightDetails();
        }

        public string showSeatingChart(string flightNumber)
        {
            return FlightDB.showSeatingChart(flightNumber);
        }
    }
}
